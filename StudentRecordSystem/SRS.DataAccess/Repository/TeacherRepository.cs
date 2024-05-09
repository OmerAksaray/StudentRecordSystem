using SRS.Data;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using SRS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.DataAccess.Repository
{
    public class TeacherRepository : Repository<TeacherModel>, ITeacherRepository
    {
        private readonly ApplicationDataContext _db;
        public TeacherRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TeacherModel teacher)
        {
            _db.TeacherModels.Update(teacher);
        }
    }
}
