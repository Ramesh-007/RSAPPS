using System.Data.Entity;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using BusinessEntities;
using System.Data.Entity.Infrastructure;

namespace DataAccessLayer
{

    public class DatabaseSettings
    {
        public static void SetDatabase()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LMSAppDAL>());
        }
    }

    public class EmployeeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employee");
            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired();
            Property(p => p.DOB).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }

    public class UserMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.IsAdmin).IsRequired();
            Property(p => p.IsLead).IsRequired();
            Property(p => p.IsManager).IsRequired();
        }
    }

    public class EmployeeAttendanceMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmployeeAttendance>
    {
        public EmployeeAttendanceMap()
        {
            ToTable("EmployeeAttendance");
            Property(p => p.Index).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.Date).IsRequired();
            Property(p => p.Status).IsRequired();
            Property(p => p.EmployeeId).IsRequired();
            Property(p => p.Week).IsRequired();
        }
    }

    public class LMSAppDAL : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendanceList { get; set; }

        public LMSAppDAL() : base(GetConnection(), false)
        {

        }

        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new EmployeeAttendanceMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
