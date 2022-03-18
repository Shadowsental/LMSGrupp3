using LMSGrupp3.Data;
using LMSGrupp3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bogus;
using Microsoft.AspNetCore.Identity;
using LMSGrupp3.Models.Entities;
using LMSGrupp3.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LMSGrupp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly Faker faker;
        private readonly UserManager<User> userManager;

        public HomeController(ApplicationDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = db.Users.Select(u => new { u.FirstName, u.LastName, u.Course}).ToList();
            return View(await db.Users.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}