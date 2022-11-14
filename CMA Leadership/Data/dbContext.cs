using CMA_Leadership.Models;
using Microsoft.EntityFrameworkCore;

namespace CMA_Leadership.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentMasterdata> StudentMasterdata { get; set; }
    }
    
}
