using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using LMSGrupp3.Models.ViewModels.Student;
using LMSGrupp3.Models.ViewModels;
using LMSGrupp3.Models.ViewModels.Teacher;
using System.Data.Common;

namespace LMSGrupp3.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction(nameof(TeacherHome));
                }
                //return RedirectToAction(nameof(Student));
            }
            return View();
        }

        // Teacher Home Page
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> TeacherHome(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var courses = from c in _context.Course select c;

            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    courses = courses.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    courses = courses.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    courses = courses.OrderBy(s => s.Name);
                    break;
            }
            var coursesList = courses.ToList();

            //var courses = await db.Courses
            //    .OrderBy(n => n.Name)
            //    .ToListAsync();

            var model = new TeacherHomeViewModel
            {
                Courses = coursesList
            };

            return View(model);
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private bool UserEmailExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
        private async Task<Course> CreateCourseSelectList(CreateUserViewModel newUser)
        {
            Course course = null;

            // newUser.CourseId is null if nothing selected in course dropdown list
            if (newUser.CourseId != null && !newUser.IsTeacher)
            {
                course = await _context.Course.FirstOrDefaultAsync(c => c.Id == newUser.CourseId);
            }

            return course;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                if (UserEmailExists(newUser.Email))
                {
                    ModelState.AddModelError(string.Empty, $"User '{newUser.Email}' already exists");
                    return View();
                }

                if (newUser.IsTeacher)
                {
                    newUser.CourseId = null;
                }

                var addUser = new User
                {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    Name = newUser.Name,
                    Course = await CreateCourseSelectList(newUser)
                };

                var createResult = await _userManager.CreateAsync(addUser, newUser.Password);

                if (createResult.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.Email);

                    // Add role(s)
                    // Before adding role, verify that roles haven't have been applied yet.
                    // All users have role Student
                    if (!await _userManager.IsInRoleAsync(createdUser, "Student"))
                    {
                        await AddUserToRoleAsync(createdUser, "Student");

                        // Add Teacher role if applicable
                        if (newUser.IsTeacher)
                        {
                            if (!await _userManager.IsInRoleAsync(createdUser, "Teacher"))
                            {
                                await AddUserToRoleAsync(createdUser, "Teacher");
                            }
                        }
                    }
                }

                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                if (ModelState.IsValid)
                {
                    ViewBag.Result = "User created successfully!";
                    ViewBag.Email = newUser.Email;
                }
            }
            return View();
        }

        private async Task<IdentityResult> AddUserToRoleAsync(User createdUser, String role)
        {
            var addToRoleResult = await _userManager.AddToRoleAsync(createdUser, role);
            if (!addToRoleResult.Succeeded)
            {
                throw new Exception(string.Join("\n", addToRoleResult.Errors));
            }
            return addToRoleResult;
        }


    }
}
