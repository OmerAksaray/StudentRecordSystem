using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SRS.Data;
using SRS.DataAccess.Repository.IRepository;

namespace SRS.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDataContext _db;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDataContext db)
        {
            _db = db;
            //burda _db.StudentModel==dbSet yapmış olduk
            this.dbSet = _db.Set<T>();

            //burada navigation propertyi eklemiş olduk
            _db.StudentModels.Include(u => u.Teacher);

        }
        public void Add(T entity)
        {
            // direkt olarak modeli kullanamayacagımızdan veya generic olarak yazamayacagımızdan burda dbSet ettim
            //_db.StudentModel.Add(entity);
            dbSet.Add(entity);
            
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
             query=query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            //burada IEnumerable (hafızada saklanandan) kullanmama sebebi IQueryablede veritabaından çekiyorsun ve queryable sorguyu alarak veri dönderebiliyor
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(includeProp);
                        
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
