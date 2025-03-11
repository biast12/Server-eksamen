using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace servereksamen
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Library { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public string DbPath { get; }
        public LibraryContext()
        {
            DbPath = "Database/library.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasNoKey();
        }
    }

    public class Library
    {
        public Books[]? Books { get; set; }
        public Genres[]? Genres { get; set; }
    }

    public class Books
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? GenreID { get; set; }
    }

    public class Genres
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}