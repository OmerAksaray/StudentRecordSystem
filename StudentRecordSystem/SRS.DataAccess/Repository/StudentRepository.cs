using Microsoft.EntityFrameworkCore;
using SRS.Data;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRS.DataAccess.Repository
{
    public class StudentRepository :  Repository<StudentModel>, IStudentRepository
    {
        private readonly ApplicationDataContext _db;
        public StudentRepository(ApplicationDataContext db): base(db)
        {
            _db = db;
        }


        public void Update(StudentModel student)
        {
            _db.StudentModels.Update(student);
            _db.SaveChanges();
        }
    }
}
