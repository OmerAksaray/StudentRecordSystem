using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.Models.Models
{
    public class TeacherModel
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        //[Required]
        //[Range(0, 500)]
        //public int Section { get; set; }
        public virtual ICollection<StudentModel>? Students { get; set; }

    }
}
