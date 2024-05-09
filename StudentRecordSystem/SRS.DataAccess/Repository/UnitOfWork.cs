using SRS.Data;
using SRS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStudentRepository Student { get; private set; }

        public ITeacherRepository Teacher { get; private set; }

        private readonly ApplicationDataContext _db;

        public UnitOfWork( ApplicationDataContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);

            Teacher = new TeacherRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
