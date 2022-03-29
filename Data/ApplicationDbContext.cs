using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMSGrupp3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCourse>()
                .HasKey(t => new { t.UserId, t.CourseId });
            modelBuilder.Entity<Course>()
                .HasIndex(b => b.Id)
                .IsUnique();
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<ActivityModel> ActivityModels { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<Document> Documents { get; set; }

    }
}