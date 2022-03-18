using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;



namespace LMSGrupp3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityType> ActivityType { get; set; }

        public DbSet<Document> Documents { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Module>();

            builder.Entity<Course>()
                .HasMany<User>(u => u.Users)
                .WithOne(c => c.Course)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<User>()
                .HasOne<Course>(c => c.Course);

            builder.Entity<Module>();

            builder.Entity<Activity>()
                .HasMany<Document>(d => d.Documents)
                .WithOne(c => c.Activity)
                .HasForeignKey(e => e.ActivityId);

            builder.Entity<ActivityType>();

            builder.Entity<Document>();

            builder.Entity<Document>();

            builder.Entity<Document>()
                .HasOne<Activity>(a => a.Activity)
                .WithMany(b => b.Documents)
                .HasForeignKey(e => e.ActivityId);

            /*** Seed Data for Activity Types ***/

            builder.Entity<ActivityType>()
                .HasData(
                    new ActivityType() { Id = 1, Name = "E-Learning" },
                    new ActivityType() { Id = 2, Name = "Lectures" },
                    new ActivityType() { Id = 3, Name = "Exercise" }
                );

            /*** Seed Data for course ***/

            SeedData.SeedCourseData(builder);

        }
    }
}


    
