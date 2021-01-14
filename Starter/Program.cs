using System;
using System.Linq;
using CRUD.Database;
using CRUD.Models;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                // Initializing the database and populating seed data
                DbInitializer.Initialize(context);

                Course ASPCourse = (from course in context.Courses
                                    where course.Name == "ASP.NET Core"
                                    select course).Single();
                Student firstStudent = new Student() { Name = "Thomas Anderson" };
                Student secondStudent = new Student() { Name = "Terry Adams" };
                ASPCourse.Students.Add(firstStudent);
                ASPCourse.Students.Add(secondStudent);
                ASPCourse.CourseTeacher.Salary += 1000;
                Student studentToRemove = ASPCourse.Students.FirstOrDefault((student) => student.Name == "Student_1");
                ASPCourse.Students.Remove(studentToRemove);
                context.SaveChanges();
                Console.WriteLine(ASPCourse);
                Console.ReadLine();
            }
        }
    }
}
