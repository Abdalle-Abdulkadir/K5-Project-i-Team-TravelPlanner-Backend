using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TravelRequest> TravelRequests { get; set; }

    public virtual DbSet<TravelResponse> TravelResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TravelRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TravelRe__3214EC077F0E80CD");

            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.FromLocation).HasMaxLength(100);
        });

        modelBuilder.Entity<TravelResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TravelRe__3214EC07A2611EFE");

            entity.Property(e => e.EstimatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SelectedDestination).HasMaxLength(200);
            entity.Property(e => e.TraceId).HasMaxLength(100);

            entity.HasOne(d => d.TravelRequest).WithMany(p => p.TravelResponses)
                .HasForeignKey(d => d.TravelRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TravelRes__Trave__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
