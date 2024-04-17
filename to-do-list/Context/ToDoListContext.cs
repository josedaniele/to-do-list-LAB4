using Microsoft.EntityFrameworkCore;
using System.Reflection;
using to_do_list.Data.Entities;

namespace to_do_list.Context
{
    public class ToDoListContext : DbContext
    {
        private readonly string _connectionString;
        public ToDoListContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString,
            sqliteOptionsAction: config => // Le decimos a EntityFramework que si la Base de Datos no está, la cree
            {
                config.MigrationsAssembly(Assembly.GetAssembly(typeof(ToDoListContext)).FullName);
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .HasOne(tdi => tdi.User)
                .WithMany()
                .HasForeignKey(tdi => tdi.UserId);
        }
    }
}
