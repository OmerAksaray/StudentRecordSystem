using Microsoft.EntityFrameworkCore;
using StudentRecordSystemWith.NetCore.Models;

namespace StudentRecordSystemWith.NetCore.Data
{
    public class ApplicationDataContext:DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<StudentModel> StudentModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
