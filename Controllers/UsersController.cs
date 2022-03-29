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
using LMSGrupp3.Models.ViewModels;
using LMSGrupp3;
using LMSGrupp3.Models.ViewModels.Student;
using LMSGrupp3.Models.ViewModels.Teacher;
using System.Data.Common;

namespace LMSGrupp3.Controllers
{

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> userManager;

        public UsersController(ApplicationDbContext _context, UserManager<User> userManager)
        {
            this._context = _context;
            this.userManager = userManager;
        }

        // GET: Users
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction(nameof(THomeViewModel));
                }
                return RedirectToAction(nameof(StudentViewModel));
            }
            return View();
        }

        [Authorize(Roles = "Teacher")]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> TUserIndex(string sortOrder)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CourseSortParm"] = sortOrder == "Course" ? "course_desc" : "Course";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";


            //var userList = await db.Users
            //    .OrderBy(u => u.LastName)
            //    .Include(a => a.Course)
            //    .ToListAsync();


            var userList = (from q in _context.Users
                            select q).Include("UserCourse");

            switch (sortOrder)
            {
                case "name_desc":
                    userList = userList.OrderByDescending(s => s.Name);
                    break;
                case "Course":
                    userList = userList.OrderBy(s => s.Courses);
                    break;
                case "course_desc":
                    userList = userList.OrderByDescending(s => s.Courses);
                    break;
                case "Email":
                    userList = userList.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    userList = userList.OrderByDescending(s => s.Email);
                    break;
                default:
                    userList = userList.OrderBy(s => s.Name);
                    break;
            }
            var userList2 = userList.ToList();




            var model = new List<UserListViewModel>();

            //foreach (var appUser in userList)
            foreach (var appUser in userList2)
            {
                model.Add(new UserListViewModel
                {
                    UserId = appUser.Id,
                    Email = appUser.Email,
                    FullName = appUser.Name,
                   // Course = appUser.Course,
                    IsTeacher = await userManager.IsInRoleAsync(appUser, "Teacher")
                });
            }

            return View(model);

        }



    }
}