using AppData.Configurations;
using AppData.Models;
using Microsoft.EntityFrameworkCore;


namespace AppData.Contexts
{
    public class NVContext : DbContext
    {
        public DbSet<NhanVien> NhanViens { get; set; }

        public NVContext() { }  
        public NVContext(DbContextOptions<NVContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NKHOC\\SQLEXPRESS;Initial Catalog=Hoc_ph27522;Persist Security Info=True;User ID=hocnk;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
        }
    }
}
