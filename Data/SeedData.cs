using Bogus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace LMSGrupp3.Data
{

    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            using var db = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var fake = new Faker("en");
            var random = new Random();

           var userManager = services.GetRequiredService<UserManager<User>>();
           
            var students = new List<User>();

            for (int i = 0; i < 50; i++)
            {
                var fName = fake.Name.FirstName();
                var lName = fake.Name.LastName();
                var studentEmail = fake.Internet.Email($"{fName} {lName}");

                var student = new User
                {
                    UserName = studentEmail,
                    FirstName = fName,
                    LastName = lName,
                    Email = studentEmail,
                   
                };

                var addStudentResult = await userManager.CreateAsync(student);

                if (!addStudentResult.Succeeded)
                {
                    throw new Exception(string.Join("\n", addStudentResult.Errors));
                }

                var studentUser = await userManager.FindByNameAsync(studentEmail);

                if (await userManager.IsInRoleAsync(studentUser, "Student"))
                {
                    continue;
                }

                var addToRoleResult = await userManager.AddToRoleAsync(studentUser, "Student");

                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception(string.Join("\n", addToRoleResult.Errors));
                }

                students.Add(student);
            }

        }
    }
}
              