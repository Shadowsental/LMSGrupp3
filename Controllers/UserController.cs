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
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly Faker faker;
        private readonly UserManager<User> userManager;

        public UserController(ApplicationDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = db.Users.Select(u => new { u.FirstName, u.LastName, u.Course }).ToList();
            return View(await db.Users.ToListAsync());
        }

        public async Task<IActionResult> UserToggle(int? id)
        {
            if (id is null) return BadRequest();

            await db.SaveChangesAsync();

            return RedirectToAction("Idnex");
        }

        public async Task<IActionResult> Details(string? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await db.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
