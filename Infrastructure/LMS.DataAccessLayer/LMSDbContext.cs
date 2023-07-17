using Microsoft.EntityFrameworkCore;
using GamaLearn.LMS.Models.Entites;

namespace GamaLearn.LMS.DataAccess
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Book> Books => Set<Book>();
    }
}
