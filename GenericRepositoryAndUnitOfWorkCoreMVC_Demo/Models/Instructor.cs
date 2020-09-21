using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Instructor Name")]
        [StringLength(100)]
        public string InstructorName { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public int Experience { get; set; }
    }
}
