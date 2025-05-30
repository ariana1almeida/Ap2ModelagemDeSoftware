using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

public class PetshopContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Tutor> Tutors { get; set; }

    public string DbPath { get; }

    public PetshopContext(DbContextOptions<PetshopContext> options) : base(options)
    {
        DbPath = System.IO.Path.Join(System.IO.Directory.GetCurrentDirectory(), "petshop.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}