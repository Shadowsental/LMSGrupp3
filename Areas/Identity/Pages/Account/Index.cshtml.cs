using System;
using LMSGrupp3.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LMSGrupp3.Data;


namespace LMSGrupp3.Areas.Identity.Pages.Account
{

    [Authorize(Roles = "Teacher")]
    public class UserModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public object ViewBag { get; private set; }

        public IEnumerable<Users_in_Role_ViewModel> Users { get; set; }

        public class InputModel
        {
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Username")]
            public string Username { get; set; }

            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Display(Name = "Role")]
            public string Role { get; set; }


        }

        public class UserViewModel
        {
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Username")]
            public string Username { get; set; }

            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Display(Name = "Role")]
            public string Role { get; set; }
        }



        public class Users_in_Role_ViewModel
        {
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public async Task<IActionResult> OnGet(string email = "", string returnUrl = null)
        {
            ReturnUrl = returnUrl;  // ?

            List<Users_in_Role_ViewModel> usersWithRoles = new List<Users_in_Role_ViewModel>();

            var users = await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                var model = new Users_in_Role_ViewModel();
                model.UserId = user.Id;
                model.Name = user.Name;
                model.Username = user.UserName;
                model.Email = user.Email;

                var roles = await _userManager.GetRolesAsync(user);
                var roleType = await _userManager.GetRolesAsync(user);
                if (roleType != null)
                    model.Role = roleType.ElementAt(0);

                usersWithRoles.Add(model);
            }

            Users = usersWithRoles;

            return Page();
        }

        //--------------------------------------




    }
}