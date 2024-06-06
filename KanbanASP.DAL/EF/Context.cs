using Microsoft.EntityFrameworkCore;
using KanbanASP.DAL.Entities;

namespace KanbanASP.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<MyTask> Tasks => Set<MyTask>();

        public Context(DbContextOptions options) : base(options) { }
        public Context() { Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=KanbanDB;User Id=kanban;Password=kanban;");
        }
    }
}
