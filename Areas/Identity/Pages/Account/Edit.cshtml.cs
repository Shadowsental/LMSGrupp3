using System;
using LMSGrupp3.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LMSGrupp3.Data;

namespace LMSGrupp3.Areas.Identity.Pages
{

    [Authorize(Roles = "Teacher")]
    public class EditUserModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public EditUserModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public object ViewBag { get; private set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} must be specified")]
            [StringLength(30, ErrorMessage = "{0} minimum of {2} and maximum of {1} characters.", MinimumLength = 3)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "{0} must be specified")]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            //=== PASSWORD AVSTÄNGD ===
            //// [Required(ErrorMessage = "{0} måste anges")]
            //[StringLength(100, ErrorMessage = "{0}et måste var minst {2} och högst {1} tecken långt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Repeat password")]
            [Compare("Password", ErrorMessage = "Passwords not equal.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} must be specified")]
            [Display(Name = "Role")]
            public string Role { get; set; }

            [Display(Name = "Select")]
            public IEnumerable<SelectListItem> Roles { get; set; }

            [Display(Name = "Assign to course")]
            public int CourseId { get; set; }

            public SelectList CourseList { get; set; }

            [HiddenInput]
            public string OrgEmail { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null, string userEmail = "")
        {

            var curUser = await _userManager.GetUserAsync(HttpContext.User);

            ReturnUrl = returnUrl;


            if (userEmail == "" && Input.OrgEmail != "")
                userEmail = Input.OrgEmail;

            if (userEmail != "")
            {
                User user = await _userManager.FindByEmailAsync(userEmail);

                Input = new InputModel();

                if (user != null)
                {
                    Input.Name = user.Name;
                    Input.Email = user.Email;
                    Input.OrgEmail = userEmail;

                    var role = "";
                    var roleType = await _userManager.GetRolesAsync(user);
                    if (roleType != null)
                    {
                        role = roleType.ElementAt(0);
                    }
                    Input.Roles = new SelectList(_roleManager.Roles, "Name", "Name", role);

                    var actCourse = _context.UserCourse.FirstOrDefault(c => c.UserId == user.Id);
                    if (actCourse != null)
                        Input.CourseId = actCourse.CourseId;
                    else
                        Input.CourseId = 0;

                    var allCourses = from course in _context.Course
                                     select new { Id = course.Id, Name = course.Name };

                    Input.CourseList = new SelectList(allCourses, "Id", "Name", Input.CourseId);
                }

                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string userEmail = "")
        {
            if (returnUrl == null)
                returnUrl = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = await _userManager.FindByEmailAsync(Input.OrgEmail);
            if (user == null)
            {
                // return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                return NotFound($"Unable to load user with ID '{_userManager.FindByEmailAsync(Input.OrgEmail)}'.");
            }

            var memEmail = user.Email;
            var tmpRoles = await _userManager.GetRolesAsync(user);
            var orgRole = tmpRoles.First();

            Boolean changedUser = false;
            Boolean changedRole = false;
            Boolean changeCourse = false;
            Boolean changePassword = false;

            if (Input.Email != user.Email)
            {
                memEmail = Input.Email;  // e-mail to return
                user.UserName = Input.Email;
                user.Email = Input.Email;
                changedUser = true;
            }

            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
                changedUser = true;
            }

            if (Input.Role != orgRole)
            {
                changedRole = true;
            }

            //if ( !(Input.Password == null || Input.Password == ""))
            //{
            //    if (string.Equals(Input.Password, Input.ConfirmPassword))
            //        changePassword = true;
            //}

            UserCourse actCourse = _context.UserCourse.FirstOrDefault(c => c.UserId == user.Id);

            if (actCourse != null && (Input.CourseId != actCourse.CourseId) || actCourse == null && Input.CourseId > 0)
            {
                changeCourse = true;
            }

            if (changedUser || changeCourse || changedRole || changePassword)
            {
                IdentityResult updateUser = null;
                IdentityResult updateRole = null;
                // IdentityResult updateCourse = null;
                // IdentityResult updatePassword = null;

                if (changedUser)
                {
                    updateUser = await _userManager.UpdateAsync(user);
                    if (!updateUser.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                    }
                }

                if (changeCourse)
                {
                    if (actCourse != null && (Input.CourseId != actCourse.CourseId))  //edit/delete student/course
                        CourseHandling(actCourse, user.Id, Input.CourseId);
                    else if (actCourse == null && Input.CourseId > 0)  // assign student to course
                        CourseHandling(actCourse, user.Id, Input.CourseId);
                }

                if (changedRole)
                {
                    // assign user from role
                    updateRole = await _userManager.RemoveFromRoleAsync(user, orgRole);
                    if (!updateRole.Succeeded)
                    {
                        throw new Exception(string.Join("\n", updateRole.Errors));
                    }

                    // assignt user to role
                    updateRole = await _userManager.AddToRoleAsync(user, Input.Role);
                    if (!updateRole.Succeeded)
                    {
                        throw new Exception(string.Join("\n", updateRole.Errors));
                    }
                }

                //if (changePassword)  //---  ---//
                //{
                //    //if (PasswordValidator != null)
                //    //{
                //    //    var passwordResult = await PasswordValidator.ValidateAsync(password);
                //    //    if (!password.Result.Success)
                //    //        return passwordResult;
                //    //}


                //    var tmp = _userManager.PasswordHasher.HashPassword(user, Input.Password);
                //    updatePassword = await _userManager.UpdateAsync(user);
                //    if (!updatePassword.Succeeded)
                //    {
                //        throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                //    }
                //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                //    var resultPw = await _userManager.ResetPasswordAsync(user, token, Input.Password);
                //}

                //#####ERROR MESSAGE??? #####
                // ???
                // ???

                // TempData["newUser"] = "Changed " + Input.Name;  //  "Created User '" + Input.Name + "' (" + Input.Role + ")";
                TempData["newUser"] = "Updated User ";
                TempData["newUserData"] = "";  // Input.Name + " (" + Input.Email + ")";

                if (returnUrl == "")
                {
                    return LocalRedirect("/Identity/Account/Details?userEmail=" + user.UserName);  // /Identity/Account/Details?userEmail=s@s.com
                }
            }

            //--- Build Outdata with update form ---

            // Role/Roles
            user = await _userManager.FindByIdAsync(user.Id.ToString());
            var role = "";

            var roleType = await _userManager.GetRolesAsync(user);
            if (roleType != null)
            {
                role = roleType.ElementAt(0);
            }
            Input.Roles = new SelectList(_roleManager.Roles, "Name", "Name", role);

            // Course/Course
            var actCourse2 = _context.UserCourse.FirstOrDefault(c => c.UserId == user.Id);
            if (actCourse2 != null)
            {
                Input.CourseId = actCourse2.CourseId;
            }
            else
                Input.CourseId = 0;

            var allCourses = from course in _context.Course
                             select new { Id = course.Id, Name = course.Name };

            Input.CourseList = new SelectList(allCourses, "Id", "Name", Input.CourseId);

            return Page();
        }

        public Boolean CourseHandling(UserCourse actCourse, string userId, int newCourseId)
        {
            Boolean success = false;
            // Boolean error = false;

            if (userId != "" && newCourseId >= 0)
            {
                if (actCourse == null)
                {
                    var newCourse = new UserCourse
                    {
                        UserId = userId,
                        CourseId = newCourseId
                    };

                    _context.Add(newCourse);  // Assign to course
                    _context.SaveChanges();
                }
                else
                {
                    _context.Remove(actCourse);  // remove, update
                    _context.SaveChanges();

                    if (newCourseId > 0)
                    {  // only update
                        actCourse.CourseId = newCourseId;
                        _context.Add(actCourse);
                        _context.SaveChanges();
                    }
                }
            }

            // if (error == false)
            success = true;

            return success;
        }
    }
}
