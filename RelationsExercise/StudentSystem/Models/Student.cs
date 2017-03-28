﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Student
    {
        public Student()
        {

        }
        public Student(string name, DateTime registrationDate)
        {
            this.Birthday = new DateTime(1960,01,01);
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.StudentName = name;
            this.RegistrationDate = registrationDate;

        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
