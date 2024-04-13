using Domain.Aggregates.Accounts;
using Domain.Aggregates.Blogs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context;
public class ApplicationDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Blog> Blogs { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
