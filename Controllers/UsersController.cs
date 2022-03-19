using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models;
using LMSGrupp3.Data;

namespace LMSGrupp3.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _applicationDb;

        public UsersController(ApplicationDbContext context, ApplicationDbContext applicationDb)
        {
            _context = context;
            _applicationDb = applicationDb;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var db = _applicationDb.User.Select(o => o.FirstName);

            var ret = _context.User.Select(o => o.Course);

            

            return View(await _context.User.ToListAsync());
        }
    }
}