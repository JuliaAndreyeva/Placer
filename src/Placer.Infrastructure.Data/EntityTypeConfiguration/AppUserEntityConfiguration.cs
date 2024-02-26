using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placer.Core.Entities;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(
        EntityTypeBuilder<AppUser> builder)
    {
        builder.UseTptMappingStrategy();
        
    }
}