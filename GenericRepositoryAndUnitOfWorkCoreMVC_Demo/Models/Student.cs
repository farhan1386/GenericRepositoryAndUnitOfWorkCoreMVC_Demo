using System;
using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Display(Name = "Fee")]
        [DataType(DataType.Currency)]
        public int CourseFee { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int CourseDuration { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime CourseStartDate { get; set; }

        [Required]
        [Display(Name = "Batch Timing")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public DateTime BatchTiming { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
