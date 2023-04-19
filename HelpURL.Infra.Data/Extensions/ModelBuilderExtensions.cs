using HelpURL.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HelpURL.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new URLMap());
        }
    }
}
