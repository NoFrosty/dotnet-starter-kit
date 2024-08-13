using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Persistence;
internal sealed class EnglishDbInitializer(
    ILogger<EnglishDbInitializer> logger,
    EnglishDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for english module", context.TenantInfo!.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {

        // Seed Npcs
        const string NpcNameMuzzy = "Muzzy";
        const string NpcNameBurn = "Burn";
        const string NpcNameCube = "Cube";
        const string NpcNameRoxy = "Roxy";
        const string NpcNameOllie = "Ollie";
        const string NpcNameNova = "Nova";
        const string NpcNameBeebee = "Beebee";
        const string NpcNameLuna = "Luna";
        const string NpcNameFurry = "Furry";

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameMuzzy, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameMuzzy);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameBurn, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameBurn);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameCube, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameCube);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameRoxy, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameRoxy);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameOllie, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameOllie);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameNova, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameNova);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameBeebee, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameBeebee);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameLuna, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameLuna);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }

        if (await context.Npcs.FirstOrDefaultAsync(t => t.Name == NpcNameFurry, cancellationToken).ConfigureAwait(false) is null)
        {
            var npc = NpcItem.Create(NpcNameFurry);
            await context.Npcs.AddAsync(npc, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default npc data", context.TenantInfo!.Identifier);
        }
    }
}
