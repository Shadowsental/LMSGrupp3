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

namespace LMSGrupp3.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RegisterModel(UserManager<User> userManager,
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

        public string CourseName { get; set; }
        //public string UserRole { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} must be specified")]
            [StringLength(30, ErrorMessage = "{0} minimum of {2} and maximum of {1} characters.", MinimumLength = 3)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} must be specified")]
            [StringLength(100, ErrorMessage = "{0} minimum of {2} and maximum of {1} characters.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} must be specified")]
            [StringLength(20, MinimumLength = 1)]
            [Display(Name = "Role")]
            public string Role { get; set; }
            public IEnumerable<SelectListItem> Roles { get; set; }

            [Display(Name = "Attach to Course")]
            public int CourseId { get; set; }
            public IEnumerable<SelectListItem> Courses { get; set; }
        }


        public IActionResult OnGet(string returnUrl = null, int courseId = 0)
        {
            ReturnUrl = returnUrl;

            if (Input == null)
            {
                Input = new InputModel();
                Input.CourseId = courseId;

                if (courseId > 0)
                {
                    Input.Courses = new SelectList(_context.Course.Where(c => c.Id == courseId).ToList(), "Id", "Name", courseId);
                    CourseName = _context.Course.Where(c => c.Id == courseId).SingleOrDefault().Name.ToString();
                    Input.Roles = new SelectList(_roleManager.Roles.Where(r => r.Name == "Student").ToList(), "Name", "Name", "Student");  // , "Student"
                }
                else
                {
                    Input.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
                    Input.Courses = new SelectList(_context.Course.ToList(), "Id", "Name", Input.CourseId);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Name = Input.Name, UserName = Input.Email, Email = Input.Email };

                if (user != null)
                {
                    // Skapa anv�ndaren
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        // Koppla anv�ndaren till en roll
                        var svar = await _userManager.AddToRoleAsync(user, Input.Role);
                        if (!svar.Succeeded)
                        {
                            throw new Exception(string.Join("\n", svar.Errors));
                        }

                        #region SendEmail
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.Page(
                        //    "/Account/ConfirmEmail",
                        //    pageHandler: null,
                        //    values: new { userId = user.Id, code = code },
                        //    protocol: Request.Scheme);

                        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        // await _signInManager.SignInAsync(user, isPersistent: false);
                        #endregion

                        if (Input.CourseId > 0)  // Koppla anv�ndare till kurs
                        {
                            // Koppla anv�ndare till en kurs
                            var newCourse = new UserCourse
                            {
                                UserId = user.Id,
                                CourseId = Input.CourseId
                            };

                            _context.Add(newCourse);
                            _context.SaveChanges();
                        }

                        if (returnUrl == "" || returnUrl == null)
                        {
                            string roll = "";
                            if (Input.Role == "Teacher")
                                roll = "l�rare";
                            else
                                roll = "elev";

                            TempData["newUser"] = "Skapade ny " + roll;
                            TempData["newUserData"] = Input.Name + " (" + Input.Email + ")";

                            returnUrl = "/Identity/Account/Details?userEmail=" + Input.Email;
                        }
                        else
                        {
                            TempData["newUserData"] = "Skapade ny elev p� kursen: " + Input.Name + " (" + Input.Email + ")";

                            returnUrl = returnUrl + "/" + Input.CourseId;  //  courseId=2&returnUrl=/Courses/Details
                        }

                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // Skapa data vid fel
            if (Input.CourseId > 0)
            {
                // Bara student
                Input.Roles = new SelectList(_roleManager.Roles.Where(r => r.Name == "Student").ToList(), "Name", "Name", "Student");  // , "Student"
                // Bara r�tt kurs i listan
                Input.Courses = new SelectList(_context.Course.Where(c => c.Id == Input.CourseId).ToList(), "Id", "Name", Input.CourseId);
                // Kursens namn
                CourseName = _context.Course.Where(c => c.Id == Input.CourseId).SingleOrDefault().Name.ToString();
            }
            else
            {
                // Lista roller
                Input.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
                // Lista kurser
                Input.Courses = new SelectList(_context.Course.ToList(), "Id", "Name", Input.CourseId);
            }


            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}