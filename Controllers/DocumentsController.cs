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
using LMSGrupp3.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace LMSGrupp3.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment web;
        private readonly UserManager<User> userManager;

        public DocumentsController(ApplicationDbContext _context, UserManager<User> userManager, IWebHostEnvironment web)
        {
            this._context = _context;
            this.userManager = userManager;
            this.web = web;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Document.ToListAsync());
        }
    }
}