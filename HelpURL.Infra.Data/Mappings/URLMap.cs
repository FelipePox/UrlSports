using HelpURL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpURL.Infra.Data.Mappings;

public sealed class URLMap : IEntityTypeConfiguration<URL>
{
    public void Configure(EntityTypeBuilder<URL> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(u => u.URLTexto, url =>
        {
            url.Property(n => n.Texto)
            .HasColumnName("URL")
            .HasColumnType("varchar(200)");

            url.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Descricao, desc =>
        {
            desc.Property(n => n.Texto)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(255)");

            desc.Ignore(n => n.Notifications);
        });

        builder.Ignore(n => n.Notifications);

    }
}
