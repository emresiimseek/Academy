using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AcedemyContext : DbContext
    {
        public AcedemyContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcedemyContext, Migrations.Configuration>());
            Database.SetInitializer(new MyInitilazer()); //when you initilazer open this row
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceDetail> AttendanceDetails { get; set; }
    }

}
