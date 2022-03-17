using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Bogus;

namespace LMSGrupp3.Data
{
    public class ApplicationDbContext : IdentityDbContext<People>
    {
        private ApplicationDbContext applicationDbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LMSGrupp3.Models.Entities.People> people { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);

        }

        private void SeedUsers(ModelBuilder builder)
        {
            Faker faker = new Faker();
            for(int i = 0; i < 10; i++)
            {

                People people = new People()
                {
                    Id = i,
                    Name = faker.Name.FullName(),
                    Email = faker.Internet.Email(),
                    BirthDate = faker.Date.Past()
                };

                builder.Entity<People>().HasData(people);
            }

        }
    }
}