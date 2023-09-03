using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MyDbContext: DbContext
    {
        public DbSet<UserEntity> MyObjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyDb.db");
        }                
    }
}