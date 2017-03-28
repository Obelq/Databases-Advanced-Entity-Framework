namespace StudentSystem.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentSystem.StudentSystemContext context)
        {

            var course1 = new Course("Programming Basics", new DateTime(2012, 12, 01), new DateTime(2014, 01, 01), 50.20m);
            var course2 = new Course("C# Advanced", new DateTime(2013, 12, 01), new DateTime(2015, 01, 01), 60.20m);
            var course3 = new Course("C# OOP", new DateTime(2015, 12, 01), new DateTime(2017, 01, 01), 100.20m);
            var course4 = new Course("SQL", new DateTime(2010, 12, 01), new DateTime(2011, 01, 01), 20.20m);
            context.Courses.AddOrUpdate(c => c.CourseName, course1, course2, course3, course4);


            context.Resources.AddOrUpdate(r => r.ResourceName,
                new Resource("Kniga1", ResourceEnum.document, "www.knigi.org", course1),
                new Resource("Kniga3", ResourceEnum.document, "www.knigi.org", course2),
                new Resource("Prezentaciq1", ResourceEnum.presentation, "www.knigi.org", course4),
                new Resource("Video1", ResourceEnum.video, "www.knigi.org", course3)
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

            context.Students.AddOrUpdate(s => s.StudentName, student1, student2, student3, student4);


            context.Homeworks.AddOrUpdate(h => h.HomeWorkContent,
                new Homework("Suchinenie Razsujdenie", ContentTypeEnum.pdf, DateTime.Now, course1, student2),
                new Homework("Razkaz", ContentTypeEnum.pdf, DateTime.Now, course3, student1),
                new Homework("Prezentaciq", ContentTypeEnum.pdf, DateTime.Now, course2, student2),
                new Homework("Sait", ContentTypeEnum.pdf, DateTime.Now, course1, student3),
                new Homework("Proekt", ContentTypeEnum.pdf, DateTime.Now, course4, student1),
                new Homework("Most", ContentTypeEnum.pdf, DateTime.Now, course1, student2)

                );
            context.SaveChanges();

        }
    }
}
