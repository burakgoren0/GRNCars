using GRNCars.Entities;
using Microsoft.EntityFrameworkCore;

namespace GRNCars.DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LENOVO\MSSQLSERVER01;Database=GRNCarsNetCore;Trusted_Connection=true;Trust server Certificate=true;");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().Property(b => b.Name).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Admin",
                IsActive = true,
                UploadDate = DateTime.Now,
                Email = "admin@grncars.tc",
                UserName = "admin",
                Password = "qweasd",
                RoleId = 1,
                Surname = "admin",
                PhoneNumber = "0850",
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
