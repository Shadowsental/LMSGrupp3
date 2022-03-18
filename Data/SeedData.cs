using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace LMSGrupp3.Data
{
    public static class SeedData
    {
        private static Faker faker = new Faker();
        private static IEnumerable<Course> courses;
        private static UserManager<User> userManager;
        private static RoleManager<IdentityRole> roleManager;

        public static async Task InitAsync(ApplicationDbContext db, Microsoft.AspNetCore.Identity.UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager)
        {

            if (await db.Users.AnyAsync()) return; 

             userManager = usermanager;
            roleManager = rolemanager;

          
            courses = GetCourses();
            await db.AddRangeAsync(courses);

            await GetStudents();
            //await db.AddRangeAsync(students);


            //var activities = GetActivities();
            //await db.AddRangeAsync(activities);

            await db.SaveChangesAsync();
        }


        //Students
        private static async Task GetStudents()
        {
                await CreateRole("Student");
            for (int i = 0; i < 10; i++)
            {

                var firstname = faker.Name.FirstName();
                var lastname = faker.Name.LastName();
                var email = faker.Internet.Email($"{firstname} {lastname}");
                User student = new User()
                {
                    FirstName =  firstname,
                    LastName = lastname,
                    UserName = email,
                    Email = email
                    
                };

                await userManager.CreateAsync(student, "Bytmig53!");
                await userManager.AddToRoleAsync(student, "Student");
            }
        }

        private static async Task CreateRole(string roleName)
        {
            var res = await roleManager.CreateAsync(new IdentityRole { Name = roleName });
        }


        //Teachers
        private static IEnumerable<User> GetTeachers()
        {
            var teachers = new List<User>();

            for(int i = 0; i < 3; i++)
            {
                User teacher = new User()
                {
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName()
                };
                teachers.Add(teacher);
            }
            return teachers;
        }


        //Courses
        private static IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>();

            for (int i = 0; i < 4; i++)
            {
                Course course = new Course()
                {
                    CourseName = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    StartDate = DateTime.Now
                };
                courses.Add(course);
            }

            return courses;
        }


        //Activities
        private static IEnumerable<Activity> GetActivities()
        {
            var activities = new List<Activity>();

            for (int i = 0; i < 2; i++)
            {
                Activity activity = new Activity()
                {
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    StartTime = faker.Date.Past(),
                    EndTime = faker.Date.Future()
                };
                activities.Add(activity);
            }

            return activities;
        }


        //Activity Types
        private static IEnumerable<ActivityType> GetActivityTypes()
        {
            var activityTypes = new List<ActivityType>();

            for(int i = 0; i < 2; i++)
            {
                ActivityType activityType = new ActivityType()
                {
                    Name = faker.Company.CompanyName()
                };
                activityTypes.Add(activityType);
            }
            return activityTypes;
        }

        //Modules
        private static IEnumerable<Module> GetModules()
        {
            var modules = new List<Module>();

            for(int i = 0; i < 2; i++)
            {
                Module module = new Module()
                {
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    StartTime = faker.Date.Past(),
                    EndTime = faker.Date.Future()
                };
                modules.Add(module);
            }

            return modules;
        }
    }
}
