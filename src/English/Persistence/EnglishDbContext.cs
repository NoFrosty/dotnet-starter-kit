using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.Starter.WebApi.English.Persistence;
public sealed class EnglishDbContext : FshDbContext
{
    public EnglishDbContext(IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor, DbContextOptions<EnglishDbContext> options, IPublisher publisher, IOptions<DatabaseOptions> settings)
        : base(multiTenantContextAccessor, options, publisher, settings)
    {
    }

    public DbSet<BeanItem> Beans { get; set; } = null!;
    public DbSet<HeartItem> Hearts { get; set; } = null!;

    public DbSet<CardItem> Cards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnglishDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.English);

        modelBuilder.Entity<CardItem>().Property(p => p.UnlockedCards)
            .HasColumnType("jsonb");
    }
}
