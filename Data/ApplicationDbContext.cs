using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace LMSGrupp3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LMSGrupp3.Models.Entities.User> Users { get; set; }
        public DbSet<LMSGrupp3.Models.Entities.Course> Courses { get; set; }
        public DbSet<LMSGrupp3.Models.Entities.Activity> Activities { get; set; }
    }
}