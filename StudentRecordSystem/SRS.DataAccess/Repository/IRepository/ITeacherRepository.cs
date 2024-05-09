using SRS.Models;
using SRS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.DataAccess.Repository.IRepository
{
    public interface ITeacherRepository:IRepository<TeacherModel>
    {

        void Update(TeacherModel teacher);
    }
}
