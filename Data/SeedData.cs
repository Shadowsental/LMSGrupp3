using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3
{
    public partial class Program
    {
        public class newUser
        {
            public string Name;
            public string Email;
            public string Password;
            public string? Role;
        }

        public static class SeedData
        {
            public static async Task Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                {
                    var userManager = serviceProvider.GetService<UserManager<User>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (roleManager == null || userManager == null)
                    {
                        throw new Exception("roleManager or userManager is null");
                    }

                    // Roles
                    var roleNames = new[] { "Teacher", "Student" };
                    foreach (var name in roleNames)
                    {
                        // Lägg till rollen om den inte finns
                        bool adminRoleExists = await roleManager.RoleExistsAsync(name);
                        if (!adminRoleExists)
                        {
                            var role = new IdentityRole { Name = name };
                            var result = await roleManager.CreateAsync(role);
                            if (!result.Succeeded)
                            {
                                throw new Exception(string.Join("\n", result.Errors));
                            }
                        }
                    }

                    // Teacher
                    var newUser = new newUser();
                    newUser.Name = "David";
                    newUser.Email = "david@teacher.com";
                    newUser.Password = "Teacher-01";
                    newUser.Role = "Teacher";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    // Student
                    newUser = new newUser();
                    newUser.Name = "Alex";
                    newUser.Email = "alex@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    newUser = new newUser();
                    newUser.Name = "Mattias";
                    newUser.Email = "mattias@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    newUser = new newUser();
                    newUser.Name = "Alicia";
                    newUser.Email = "alicia@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    newUser = new newUser();
                    newUser.Name = "Stina";
                    newUser.Email = "stina@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    newUser = new newUser();
                    newUser.Name = "Adam";
                    newUser.Email = "adam@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    newUser = new newUser();
                    newUser.Name = "Marie";
                    newUser.Email = "marie@student.com";
                    newUser.Password = "Student-1";
                    newUser.Role = "Student";
                    await CreateUserAsync(userManager, roleManager, newUser);

                    var indexPicker = new Random();

                    // Seed ActivityType
                    if (context.ActivityType.Count() == 0)
                    {
                        var activityTypes = new List<ActivityType>();
                        activityTypes.Add(new ActivityType { Name = "E-Learning", Description = "Student can learn wherever whenever" });
                        activityTypes.Add(new ActivityType { Name = "Lecture", Description = "Teacher on the same spot with the students in a physcial place" });
                        activityTypes.Add(new ActivityType { Name = "Exercise", Description = "Student Assignments to keep practicing" });
                        activityTypes.Add(new ActivityType { Name = "Other", Description = "Misc. activities" });
                        //context.ActivityType.RemoveRange(context.ActivityType);
                        context.ActivityType.AddRange(activityTypes);
                        context.SaveChanges();
                    }


                    // Seed Course
                    if (context.Course.Count() == 0)
                    {
                        var courses = new List<Course>();
                        courses.Add(new Course { Name = ".NET", Description = "Coding course in Microsoft .NET.", StartDate = DateTime.Parse("2022-01-26") });
                        courses.Add(new Course { Name = "Javascript", Description = "Coding course in Javascript.", StartDate = DateTime.Parse("2022-02-05") });
                        courses.Add(new Course { Name = "Computer Whiz", Description = "Profess in Computers.", StartDate = DateTime.Parse("2022-02-25") });
                        //context.Course.RemoveRange(context.Course);
                        context.Course.AddRange(courses);
                        context.SaveChanges();
                    }

                    // Seed UserCourse
                    context.UserCourse.ToList().ForEach(userCourse => context.Remove(userCourse));
                    context.SaveChanges();

                    if (context.UserCourse.Count() == 0)
                    {
                        var courseIds = context.Course.Select(a => a.Id).ToArray();
                        var userIds = context.Users.Select(a => a.Id).ToArray();

                        var userCourses = new List<UserCourse>();
                        for (int i = 0; i < userIds.Length; i++)
                            userCourses.Add(new UserCourse
                            {
                                UserId = userIds[i]
                                ,
                                CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)]
                            });

                        //context.Course.RemoveRange(context.Course);
                        context.UserCourse.AddRange(userCourses);
                        context.SaveChanges();
                    }

                    // Seed Module .NET Påbyggnadsutbildning
                    context.Module.ToList().ForEach(module => context.Remove(module));
                    context.SaveChanges();
                    if (context.Module.Count() == 0)
                    {
                        var courseIds = context.Course.Select(a => a.Id).ToArray();
                        var modules = new List<Module>();
                        modules.Add(new Module { Name = "C#", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "C# 7 (Polymorphism, Generics, Linq)", StartTime = DateTime.Parse("2021-11-26"), EndTime = DateTime.Parse("2021-12-14") });
                        modules.Add(new Module { Name = "Testing", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "Unit Testing etc.", StartTime = DateTime.Parse("2021-12-17"), EndTime = DateTime.Parse("2022-01-02") });
                        modules.Add(new Module { Name = "Web", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "HTML5, CSS3, JavaScript.", StartTime = DateTime.Parse("2021-01-03"), EndTime = DateTime.Parse("2021-01-14") });
                        modules.Add(new Module { Name = "MVC", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "ASP.NET MVC Core.", StartTime = DateTime.Parse("2021-01-15"), EndTime = DateTime.Parse("2021-01-30") });
                        modules.Add(new Module { Name = "Database", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "Entity framework & SQL.", StartTime = DateTime.Parse("2021-01-31"), EndTime = DateTime.Parse("2021-02-08") });
                        modules.Add(new Module { Name = "Webbapp", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "Frontend Superskills.", StartTime = DateTime.Parse("2021-02-11"), EndTime = DateTime.Parse("2021-02-21") });
                        modules.Add(new Module { Name = "MVC Nex Level", CourseId = courseIds[indexPicker.Next(0, courseIds.Length - 1)], Description = "Teamwork Full-stack App.", StartTime = DateTime.Parse("2021-02-22"), EndTime = DateTime.Parse("2021-03-22") });
                        //context.Module.RemoveRange(context.Module);
                        context.Module.AddRange(modules);
                        context.SaveChanges();
                    }

                    // Seed ActivityModel
                    if (context.ActivityModel.Count() == 0)
                    {
                        string[] randomNames = { "Hacker One", "Fragglarna", "The Rock", "Blondinbella", "Antagonist" };
                        string[] randomWords = { "Drilldeep", "Basics", "About", "More to Add" };
                        var activityTypes = context.ActivityType.ToArray();
                        var modules = context.Module.ToArray();
                        var activityModels = new List<ActivityModel>();
                        foreach (var module in modules)
                        {
                            for (int i = 0; i < indexPicker.Next(1, 10); i++)
                            {
                                var activityTypeIndex = indexPicker.Next(0, activityTypes.Length - 1);
                                var dateIndex = (module.EndTime - module.StartTime).Days;
                                var startDate = module.StartTime.AddDays(indexPicker.Next(0, dateIndex - 3)).AddHours(9);
                                var stopDate = startDate.AddDays(indexPicker.Next(0, 3)).AddHours(8);
                                activityModels.Add(new ActivityModel
                                {
                                    Name = randomWords[indexPicker.Next(0, randomWords.Length - 1)] + " " + module.Name,
                                    ModuleId = module.Id,
                                    ActivityTypeId = activityTypes[activityTypeIndex].Id,
                                    Description = activityTypes[activityTypeIndex].Name + " med " + randomNames[indexPicker.Next(0, randomNames.Length - 1)] + ".",
                                    StartDate = startDate,
                                    StopDate = stopDate
                                });
                            }
                        }
                        context.ActivityModel.AddRange(activityModels);
                        context.SaveChanges();
                    }
                }
            }

            private static async Task<bool> CreateUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, newUser newUser)
            {
                Boolean success = false;

                if (userManager != null && roleManager != null)
                {
                    var foundUser = await userManager.FindByEmailAsync(newUser.Email);
                    if (foundUser == null)
                    {
                        var user = new User { Name = newUser.Name, UserName = newUser.Email, Email = newUser.Email };
                        var addUserResult = await userManager.CreateAsync(user, newUser.Password);

                        if (addUserResult.Succeeded)
                        {
                            var addToRoleResultAdmin = await userManager.AddToRoleAsync(user, newUser.Role);
                            if (addToRoleResultAdmin.Succeeded)
                                success = true;
                        }
                    }
                }

                return success;
            }
        }




    }
}