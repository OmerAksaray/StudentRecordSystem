
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.Models.ViewModels
{
    public class StudentVM
    {
       
        public StudentModel _Student { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TeacherList { get; set; }
    }
}
