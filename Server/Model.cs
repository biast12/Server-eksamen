using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Library> Library { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Categories> Categories { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Library>().HasNoKey();

        // Configure ID columns to use INT instead of BIGINT
        modelBuilder.Entity<Items>()
            .Property(i => i.ID)
            .HasColumnType("int");

        modelBuilder.Entity<Genres>()
            .Property(g => g.ID)
            .HasColumnType("int");

        modelBuilder.Entity<Categories>()
            .Property(c => c.ID)
            .HasColumnType("int");
    }
}

public class Library
{
    public Items[]? Items { get; set; }
    public Genres[]? Genres { get; set; }
}

public class Items
{
    public int ID { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int GenreID { get; set; }
    public required string CategoryID { get; set; }
}

public class Genres
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string BgColor { get; set; }
}

public class Categories
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string Icon { get; set; }
}
