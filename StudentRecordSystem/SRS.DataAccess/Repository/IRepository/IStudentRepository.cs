using SRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.DataAccess.Repository.IRepository
{
    public interface IStudentRepository: IRepository<StudentModel> 
    {
        void Update(StudentModel student);

        
    }
}
