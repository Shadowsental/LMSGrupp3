using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using LMSGrupp3.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LMSGrupp3.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        private readonly IHostingEnvironment _hostingEnvironment;

        public DocumentsController(ApplicationDbContext context, IHostingEnvironment environment, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = environment;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Document.ToListAsync());
        }

        // GET: Documents/Create
        public async Task<IActionResult> Create()
        {
            DocumentFileViewModel doc = new DocumentFileViewModel();
            DateTime timestamp = DateTime.Now;
            doc.Timestamp = timestamp;

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            doc.ApplicationUserId = currentUser.Id.ToString();
            return View(doc);
        }

        //POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Timestamp,ApplicationUserId,CourseId,ModuleId,ActivityId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, DocumentFileViewModel dvm)
        {
            if (file == null || file.Length == 0)
            {
                return Content("file not selected");
            }

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "files");
            var filePath = Path.Combine(uploads, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (ModelState.IsValid)
            {
                Document doc = new Document();
                DateTime timestamp = DateTime.Now;
                doc.Name = dvm.Name;
                doc.Description = dvm.Description;
                doc.UserId = dvm.ApplicationUserId;
                doc.FileName = dvm.FileName;
                doc.Timestamp = dvm.Timestamp;
                doc.CourseId = dvm.CourseId;
                doc.ModuleId = dvm.ModuleId;
                doc.ActivityId = dvm.ActivityId;
                _context.Add(doc);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}