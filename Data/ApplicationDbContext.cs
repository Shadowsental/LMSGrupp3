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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedStudents(builder);
            this.SeedCourses(builder);
            this.SeedActivities(builder);
        }

        private void SeedStudents(ModelBuilder builder)
        {
            Faker faker = new Faker();
            for(int i = 0;i < 5; i++)
            {
                User students = new User()
                {
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Internet.Email()

                };

                builder.Entity<User>().HasData(students);
            }
        }

        private void SeedCourses(ModelBuilder builder)
        {
            Faker faker = new Faker();
            for(int i = 0; i < 2; i++)
            {
                Course courses = new Course()
                {
                    Id = i,
                    CourseName = faker.Company.CompanyName(),
                    Description = faker.Commerce.ProductDescription(),
                    StartDate = faker.Date.Past()
                };
            }
        }

        private void SeedActivities(ModelBuilder builder)
        {
            Faker faker = new Faker();
            for (int i = 0; i < 3; i++)
            {
                Activity activity = new Activity()
                {
                    Id = i,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    StartTime = faker.Date.Past(),
                    EndTime = faker.Date.Future(),
                };
            }
        }
    }
}