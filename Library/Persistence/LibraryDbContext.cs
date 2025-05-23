using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Book>(b =>
        {
            b.ToTable("Books");

            b.HasKey(k => k.Id);

            b.Property(k => k.Author).HasMaxLength(128).IsRequired();
            b.Property(k => k.Title).HasMaxLength(128).IsRequired();
            b.Property(k => k.Isbn).HasMaxLength(128).IsRequired();
            b.Property(k => k.YearOfPublication).IsRequired();
        });
    }
}