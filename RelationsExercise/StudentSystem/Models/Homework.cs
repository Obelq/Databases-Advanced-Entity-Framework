using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public enum ContentTypeEnum
    {
        application,
        pdf,
        zip
    }
    public class Homework
    {
        public Homework()
        {

        }
        public Homework(string content, ContentTypeEnum contentType, DateTime submissionDate, Course course, Student student)
        {
            this.HomeWorkContent = content;
            this.ContentType = contentType;
            this.SubmissionDate = submissionDate;
            this.Course = course;
            this.Student = student;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string HomeWorkContent { get; set; }

        [Required]
        public ContentTypeEnum ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
