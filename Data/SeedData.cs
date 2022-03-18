using Microsoft.EntityFrameworkCore;
using LMSGrupp3.Models.Entities;
using Bogus;

namespace LMSGrupp3.Data
{
    public class SeedData
    {
        private static Faker faker = new Faker();

        public static async Task InitAsync(ApplicationDbContext db)
        {
            var students = GetStudents();
            await db.AddRangeAsync(students);
        }


        //Students
        private static IEnumerable<User> GetStudents()
        {
            var students = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                User student = new User()
                {
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName()
                };

                students.Add(student);
            }
            return students;
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
                    Description = faker.Commerce.ProductDescription()
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
