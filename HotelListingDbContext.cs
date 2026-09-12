using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api;

public partial class HotelListingDbContext : DbContext
{
    public HotelListingDbContext()
    {
    }

    public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1400;Database=HotelListingDb;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasIndex(e => e.CountryId, "IX_Hotels_CountryId");

            entity.HasOne(d => d.Country).WithMany(p => p.Hotels).HasForeignKey(d => d.CountryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
