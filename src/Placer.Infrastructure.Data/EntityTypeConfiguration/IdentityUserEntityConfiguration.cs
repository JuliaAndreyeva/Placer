using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placer.Infrastructure.Data.EntityTypeConfiguration;

public class IdentityUserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(
        EntityTypeBuilder<IdentityUser> builder)
    {
        builder.UseTptMappingStrategy();
    }
}