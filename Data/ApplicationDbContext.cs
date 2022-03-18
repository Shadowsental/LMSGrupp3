using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace LMSGrupp3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}