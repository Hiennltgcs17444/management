using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppASM2.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course
    {
        public int? CourseId { get; set; }
        [Required]
        [DisplayName("Course Code")]
        public string Code { get; set; }
        [Required]
        [DisplayName("Course Name")]
        public string Name { get; set; }
        public string Decription { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
    public class Class
    {
        public int? ClassId { get; set; }
        [Required]
        [DisplayName("Class Code")]
        public string Code { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime StartDay { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<TraineeClass> TraineeClasses { get; set; }  
    }
    public class TraineeClass
    {
        public int? TraineeClassId { get; set; }
        public string Grade { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Trainee { get; set; }
    }
    public class Topic
    {
        public int? TopicId { get; set; }
        [Required]
        [DisplayName("Topic Name")]
        public string Name { get; set; }
        public string Decription { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Trainer { get; set; }
    }
}