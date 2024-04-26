using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystemWith.NetCore.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [Range(0, 500)]
        public int  SchoolNumber{ get; set; }
    }
}
