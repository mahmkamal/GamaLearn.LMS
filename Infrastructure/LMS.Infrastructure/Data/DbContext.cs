using LMS.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using LMS.Models.Entites;

namespace LMS.Infrastructure
{
    public class TaskDbContext : DbContext, ITaskDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options){}
        public DbSet<Book>? Books { get; set; }
    }
}
