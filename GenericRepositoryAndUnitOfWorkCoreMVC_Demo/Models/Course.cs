using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Course")]
        public string CourseName { get; set; }
    }
}
