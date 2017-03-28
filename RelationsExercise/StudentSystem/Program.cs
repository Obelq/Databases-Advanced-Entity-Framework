using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            //context.Database.Initialize(true);

            //TestSeed(context);

            WorkingWithTheDatabase(context);
        }

        private static void WorkingWithTheDatabase(StudentSystemContext context)
        {
            Console.Write("Enter number of command in range of 1-5: ");

            var input = int.Parse(Console.ReadLine());
            
            switch (input)
            {
                case 1:
                    var students = context.Students;
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.StudentName);
                        foreach (var homework in student.Homeworks)
                        {
                            Console.WriteLine($"-- Content: {homework.HomeWorkContent} | Content type:{homework.ContentType}");
                        }
                    }
                    break;
                case 2:
                    var courses = context.Courses.OrderBy(c => c.StartDate).OrderByDescending(c => c.EndDate);
                    foreach (var c in courses)
                    {
                        Console.WriteLine(c.CourseName);
                        Console.WriteLine(c.Description);
                        foreach (var r in c.Resources)
                        {
                            Console.WriteLine($"{r.ResourceName} | {r.TypeOfResource} | {r.URL}");
                        }
                    }
                    break;
                case 3:
                    var courses5 = context.Courses
                        .Where(c => c.Resources.Count > 5)
                        .OrderByDescending(c => c.Resources.Count)
                        .OrderByDescending(c=>c.StartDate);
                    foreach (var c in courses5)
                    {
                        Console.WriteLine(c.CourseName +$" have {c.Resources.Count} resources.");
                    }
                    break;
                case 4:
                    Console.Write("Enter date in format yyyy-MM-dd : ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var coursesByDate = context.Courses
                        .Where(c => c.StartDate < date && c.EndDate > date)
                        .OrderByDescending(c => c.Students.Count);
                        //.OrderByDescending(c => (c.StartDate - c.EndDate));
                    foreach (var course in coursesByDate)
                    {
                        Console.WriteLine($"{course.CourseName} | {course.StartDate} | {course.EndDate} | {(course.StartDate - course.EndDate).TotalDays} | {course.Students.Count}");
                        
                    }
                    break;
                case 5:
                    var studens = context.Students
                        .OrderByDescending(s => s.Courses.Select(x => x.Price).Sum())
                        .OrderByDescending(s => s.Courses.Count)
                        .OrderBy(s => s.StudentName);
                    foreach (var s in studens)
                    {
                        Console.WriteLine(s.StudentName);
                        if (s.Courses.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{s.Courses.Count} | {s.Courses.Select(x => x.Price).Sum()} | {s.Courses.Select(x => x.Price).Average()}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalind command!");
                    break;
            }
            
        }

        private static void TestSeed(StudentSystemContext context)
        {


            var course1 = new Course("Programming Basics", new DateTime(2012, 12, 01), new DateTime(2014, 01, 01), 50.20m);
            var course2 = new Course("C# Advanced", new DateTime(2013, 12, 01), new DateTime(2015, 01, 01), 60.20m);
            var course3 = new Course("C# OOP", new DateTime(2015, 12, 01), new DateTime(2017, 01, 01), 100.20m);
            var course4 = new Course("SQL", new DateTime(2010, 12, 01), new DateTime(2011, 01, 01), 20.20m);
            //context.Courses.AddOrUpdate(c => c.Name, course1, course2, course3, course4);
            context.Resources.AddRange(new[] {
                new Resource("Kniga1", ResourceEnum.document, "www.knigi.org", course1),
                new Resource("Kniga3", ResourceEnum.document, "www.knigi.org", course2),
                new Resource("Prezentaciq1", ResourceEnum.presentation, "www.knigi.org", course4),
                new Resource("Video1", ResourceEnum.video, "www.knigi.org", course3) }
                );
            

            Student student1 = new Student("Misho", DateTime.Now);
            Student student2 = new Student("Kolcho", DateTime.Now);
            Student student3 = new Student("Todor", DateTime.Now);
            Student student4 = new Student("Peter", DateTime.Now);
            student1.Courses.Add(course1);
            student1.Courses.Add(course4);
            student2.Courses.Add(course1);
            student3.Courses.Add(course3);
            student3.Courses.Add(course2);

            context.Students.AddRange(new[] { student1, student2, student3, student4 });
            

            context.Homeworks.AddRange(new[] {
                new Homework("Suchinenie Razsujdenie", ContentTypeEnum.pdf, DateTime.Now, course1, student2),
                new Homework("Razkaz", ContentTypeEnum.pdf, DateTime.Now, course3, student1),
                new Homework("Prezentaciq", ContentTypeEnum.pdf, DateTime.Now, course2, student2),
                new Homework("Sait", ContentTypeEnum.pdf, DateTime.Now, course1, student3),
                new Homework("Proekt", ContentTypeEnum.pdf, DateTime.Now, course4, student1),
                new Homework("Most", ContentTypeEnum.pdf, DateTime.Now, course1, student2) }

                );
            context.SaveChanges();
        }
    }
}
