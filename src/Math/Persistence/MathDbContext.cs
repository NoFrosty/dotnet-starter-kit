using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.Starter.WebApi.Math.Persistence;
public sealed class MathDbContext : FshDbContext
{
    public MathDbContext(IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor, DbContextOptions<MathDbContext> options, IPublisher publisher, IOptions<DatabaseOptions> settings)
        : base(multiTenantContextAccessor, options, publisher, settings)
    {
    }

    public DbSet<ElemNumScoreItem> ElemNumScores { get; set; } = null!;
    public DbSet<MiddleLinearScoreItem> MiddleLinearScores { get; set; } = null!;
    public DbSet<MiddleLinearProgressItem> MiddleLinearProgress { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MathDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.Math);
    }
}
