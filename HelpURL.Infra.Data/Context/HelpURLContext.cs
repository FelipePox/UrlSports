using Flunt.Notifications;
using HelpURL.Domain.Entities;
using HelpURL.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HelpURL.Infra.Data.Context;

public sealed class HelpURLContext  : DbContext
{
    public HelpURLContext(DbContextOptions<HelpURLContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
    }

    public DbSet<URL> Urls => Set<URL>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<Notification>>();
        modelBuilder.ConfigureMappings();
        base.OnModelCreating(modelBuilder);
    }

}
