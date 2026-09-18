using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Api.Data.Configs;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
         new IdentityRole
         {
             Id = "83478b29-10c4-4b53-9118-2e0f49896792",
             Name = "Admin",
             NormalizedName = "ADMIN",
             ConcurrencyStamp = "a7b8c9d0-1111-2222-3333-444455556666"
         },
         new IdentityRole
         {
             Id = "c2b3e891-20f5-46a4-9b19-5d6c811234a9",
             Name = "User",
             NormalizedName = "USER",
             ConcurrencyStamp = "b8c9d0e1-7777-8888-9999-000011112222"
         },
         new IdentityRole
         {
             Id = "c2b3e891-20f5-46a4-9b19-5d6c81345a23",
             Name = "Hotel Admin",
             NormalizedName = "HOTEL ADMIN",
             ConcurrencyStamp = "b8c9d0e1-7777-8888-9999-000011112222"
         }
        );
    }
}