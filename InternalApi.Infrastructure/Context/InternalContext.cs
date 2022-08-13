using InternalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternalApi.Infrastructure.Context;

public class InternalContext  : DbContext
{
    public InternalContext(DbContextOptions<InternalContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)  
    {  
        base.OnModelCreating(builder);
    }
}