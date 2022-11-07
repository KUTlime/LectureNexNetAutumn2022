using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Models;

namespace SampleWebApplication.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SampleWebApplication.Models.Customer> Customer { get; set; }
    public DbSet<SampleWebApplication.Models.Order> Order { get; set; }
}