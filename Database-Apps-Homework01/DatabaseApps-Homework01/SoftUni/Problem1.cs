using System.Data.Entity;

namespace DatabaseSoftUni
{
    public class SoftUniEntities : DbContext
    {
        public SoftUniEntities()
            : base("name=Problem11")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkHour> WorkHours { get; set; }
        public virtual DbSet<WorkHoursLog> WorkHoursLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeesProjects").MapLeftKey("EmployeeID").MapRightKey("ProjectID"));

            modelBuilder.Entity<WorkHoursLog>()
                .Property(e => e.OldComments)
                .IsUnicode(false);

            modelBuilder.Entity<WorkHoursLog>()
                .Property(e => e.NewComments)
                .IsUnicode(false);

            modelBuilder.Entity<WorkHoursLog>()
                .Property(e => e.Command)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
