using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using LMSGrupp3.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Web;
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
            doc.UserId = currentUser.Id.ToString();
            return View(doc);
        }

        //POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Timestamp,UserId,CourseId,ModuleId,ActivityId")] Document document)
        {
            
                if (ModelState.IsValid) {
                    _context.Add(document);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ActivityId"] = new SelectList(_context.ActivityModel, "Id", "Id", document.ActivityId);
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", document.UserId);
                ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", document.CourseId);
                ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Id", document.ModuleId);
                return View(document);
            
        }

            [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, DocumentFileViewModel dvm)
        {
            if (files == null)
            {
                return Content("file not selected");
            }

            var uploads = this._hostingEnvironment.WebRootPath;
            var filePath = this._hostingEnvironment.ContentRootPath;

            string path = Path.Combine(this._hostingEnvironment.WebRootPath, "files");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile file in files)
            {
                string fileName = Path.GetFileName(file.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }

            if (ModelState.IsValid)
            {
                Document doc = new Document();
                DateTime timestamp = DateTime.Now;
                doc.Name = dvm.Name;
                doc.Description = dvm.Description;
                doc.UserId = dvm.UserId;
                doc.FileName = dvm.FileName;
                doc.Timestamp = dvm.Timestamp;
                doc.CourseId = dvm.CourseId;
                doc.ModuleId = dvm.ModuleId;
                doc.ActivityId = dvm.ActivityId;
                doc.Path = path;
                _context.Add(doc);
                
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DownloadFile(int? id)
        {
            Document doc = _context.Document.Find(id);
            if(id == null)
            {
                return Content("File not found");
            }

            string path = doc.Path;
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "/" + doc.FileName);
            if (fileBytes == null)
            {
                return Content("File doesn't exist");
            }

            string fileName = doc.FileName;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}