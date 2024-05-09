using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SRS.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [Range(0, 500)]
        public int  SchoolNumber{ get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        [ValidateNever]
        public TeacherModel? Teacher { get; set; }

        public string? ImageUrl { get; set; }    

    }
}
