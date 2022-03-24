using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using LMSGrupp3.ViewModels.Teacher;


namespace LMSGrupp3.Controllers
{
    //[Authorize(Roles = "Teacher,Student")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CoursesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Courses
        public async Task<IActionResult> CourseStudents()
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            UserCourse actCourse = _context.UserCourse.FirstOrDefault(c => c.UserId == currentUser.Id);
            Course classMates;

            classMates = await _context
                .Course
                .Include(aus => aus.Users)
                    .ThenInclude(au => au.User)
                .FirstOrDefaultAsync(c => c.Id == _context
                    .UserCourse
                    .FirstOrDefault(u => u.UserId == _userManager
                        .GetUserId(HttpContext.User)
                        .ToString())
                    .CourseId);

            if (classMates != null)
                ViewData["Rubrik"] = "Course Mates";
            else
                ViewData["Rubrik"] = "Not Currently assigned to Course";

            return View(classMates);
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Course
                .Include(m => m.Modules)
                .ThenInclude(ma => ma.ModuleActivities)
                .ThenInclude(at => at.ActivityType)
                .Include(auc => auc.Users)
                .ThenInclude(au => au.User)
                .ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(m => m.Modules)
                .ThenInclude(ma => ma.ModuleActivities)
                .Include(au => au.Users)
                .FirstOrDefaultAsync(m => m.Id == id)
                ;
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(CreateCourseViewModel courseModel)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Name = courseModel.Name,
                    Description = courseModel.Description,
                    StartDate = courseModel.StartDate
                };

                ViewBag.Result = "Course created successfully!";
                _context.Add(course);
                await _context.SaveChangesAsync();
                //return RedirectToAction("TeacherHome", "AppUsers");
            }
            return View();
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}