using Microsoft.EntityFrameworkCore;

namespace SampleWPFAppWithDb.Data;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
}
