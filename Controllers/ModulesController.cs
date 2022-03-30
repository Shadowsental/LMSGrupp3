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
using LMSGrupp3.Models.ViewModels.Student;
using LMSGrupp3.Models.ViewModels;
using LMSGrupp3.Extensions;
using LMSGrupp3.Models.ViewModels.Teacher;
using System.Data.Common;

namespace LMSGrupp3.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ModulesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            return View(await context.Modules.ToListAsync());
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await context.Modules
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (module == null)
            {
                return NotFound();
            }

            // All activities in the module.
            var activities = await context.ModuleActivites.Where(a => a.ModuleId == module.Id).ToListAsync();

            // All activity Ids in the module.
            var activityIds = await context.Activities.Where(a => a.ModuleId == module.Id).Select(i => i.Id).ToListAsync();

            // All documents in the module.
            var documents = await context.Documents.Where(d => d.ModuleId == module.Id)
                .Include(a => a.Activity)
                .Include(u => u.AppUser)
                .ToListAsync();

            // All documents in the activities in the module.
            foreach (var doc in await context.Documents.Include(a => a.Activity).ToListAsync())
            {
                foreach (var i in activityIds)
                {
                    if (doc.ActivityId == i)
                    {
                        if (!documents.Contains(doc))
                        {
                            documents.Add(doc);
                        }

                    }
                }
            }

            var viewmodel = new ModuleDetailsViewModel
            {
                Module = module,
                Documents = documents
            };

            return View(viewmodel);
        }


        // GET: Modules/Create
        [HttpGet]
        public IActionResult Create(int courseId)
        {
            var @module = new Module
            {
                CourseId = courseId,
                StartTime = DateTime.Parse(TempData.Peek("LastCourseStartDate").ToString()),
                EndTime = DateTime.Parse(TempData.Peek("LastCourseStartDate").ToString())
            };

            ViewData["courseTimeStart"] = "";
            ViewData["startTime"] = "";

            if (module.CourseId > 0)
            {
                var course = context.Course.Where(c => c.Id == module.CourseId).SingleOrDefault();
                if (course != null)
                {
                   

                    ViewData["courseTimeStart"] = course.StartDate.ToString("dd/MM-yy", ci);
                    ViewData["startTime"] = course.StartDate.ToString("yyyy-dd-MM");
                }
            }

            return View(@module);
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartTime,EndTime,CourseId")] Module @module)
        {
            Boolean timeError = false;

            ViewData["errorTimeStart"] = "";
            ViewData["errorTimeEnd"] = "";

            var course = context.Course.Where(m => m.Id == module.CourseId).SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (course != null)
                {
                    if (module.StartTime < course.StartDate)  // Före kurs
                    {
                        timeError = true;
                        ViewData["errorTimeStart"] = "Start Time before course Start Time, not ok.!";
                    }

                    if (module.EndTime < module.StartTime)  // Före starttid
                    {
                        timeError = true;
                        ViewData["errorTimeEnd"] = "End Time before start time, not valid!";
                    }

                    if (timeError == false)
                    {
                        context.Add(@module);
                        await context.SaveChangesAsync();
                        var url = "~/Courses/Details/" + @module.CourseId;
                        return LocalRedirect(url);
                    }
                }
            }

            // Skapa data vid fel
            // CultureInfo culture = CultureInfo.CreateSpecificCulture("sv-SE");  // en-US
            

            ViewData["courseTimeStart"] = course.StartDate.ToString("dd/MM-yy", ci);
            ViewData["startTime"] = course.StartDate.ToString("yyyy-dd-MM");

            return View(@module);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await context.Module.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartTime,EndTime, CourseId")] Module @module)
        {
            if (id != @module.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(@module);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var url = "~/Courses/Details/" + @module.CourseId;
                return LocalRedirect(url);
                //                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await context.Module
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @module = await context.Module.FindAsync(id);
            context.Module.Remove(@module);
            await context.SaveChangesAsync();
            //            return RedirectToAction(nameof(Index));
            var url = "~/Courses/Details/" + TempData.Peek("LastCourseId");
            return LocalRedirect(url);
        }

        private bool ModuleExists(int id)
        {
            return context.Module.Any(e => e.Id == id);
        }
    }
}