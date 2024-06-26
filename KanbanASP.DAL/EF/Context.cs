﻿using Microsoft.EntityFrameworkCore;
using KanbanASP.DAL.Entities;

namespace KanbanASP.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();

        public Context(DbContextOptions options) : base(options) { }
        public Context() { Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseNpgsql("host=localhost port=5432 dbname=postgres user=postgres password=qwerty");
        }
    }
}
