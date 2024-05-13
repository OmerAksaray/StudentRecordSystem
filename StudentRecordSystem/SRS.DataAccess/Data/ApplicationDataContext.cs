using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SRS.Models;
using SRS.Models.Models;



namespace SRS.Data
{
    public class ApplicationDataContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<StudentModel> StudentModels { get; set; }

        public DbSet<TeacherModel> TeacherModels { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentModel>().HasData(
            //    new StudentModel { StudentId = 167, Name = "Sevgi", Surname = "Aksaray", SchoolNumber = 15, TeacherID = 2 }
            //    );
            //modelBuilder.Entity<TeacherModel>().HasData(
            //    new TeacherModel { TeacherId = 2, Name = "Ömer", Surname = "Aksaray", Section = 2 }
            //    );
            base.OnModelCreating(modelBuilder);     
            modelBuilder.Entity<TeacherModel>().HasData(
                new TeacherModel { Name="Omer", Surname="Aksaray",  TeacherId=2 }
                
                );
            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel { Name="Sevgi", Surname="Aksaray", StudentId=2, TeacherId=2, SchoolNumber=167}
                );
            modelBuilder.Entity<TeacherModel>().HasData(
                new TeacherModel { Name = "Yilmaz", Surname = "Aksaray", TeacherId = 5 }

                );
        }
    }
}
