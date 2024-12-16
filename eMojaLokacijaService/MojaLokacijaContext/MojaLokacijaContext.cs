using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eMojaLokacijaService.MojaLokacijaContext.Models;

namespace eMojaLokacijaService.MojaLokacijaContext;

public partial class MojaLokacijaContext : DbContext
{
    public MojaLokacijaContext(DbContextOptions<MojaLokacijaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FunLocation> FunLocation { get; set; }

    public virtual DbSet<LocationType> LocationType { get; set; }

    public virtual DbSet<MyFunLocation> MyFunLocation { get; set; }

    public virtual DbSet<MyLocation> MyLocation { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<VFunLocationGeoPoint> VFunLocationGeoPoint { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FunLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Locations_FunLocation");

            entity.ToTable("FunLocation", "Locations");

            entity.HasIndex(e => e.TypeId, "IX_TypeID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GeoPoint).HasColumnType("geometry");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.FunLocation)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_FunLocation_Assignment");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Locations_LocationType_Type");

            entity.ToTable("LocationType", "Locations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MyFunLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Locations_MyFunLocation");

            entity.ToTable("MyFunLocation", "Locations");

            entity.HasIndex(e => e.MyLocationId, "IX_Locations_MyFunLocation_MyLocationID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FunLocationId).HasColumnName("FunLocationID");
            entity.Property(e => e.MyLocationId).HasColumnName("MyLocationID");

            entity.HasOne(d => d.FunLocation).WithMany(p => p.MyFunLocation)
                .HasForeignKey(d => d.FunLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_MyFunLocation_MyFunLocationID");

            entity.HasOne(d => d.MyLocation).WithMany(p => p.MyFunLocation)
                .HasForeignKey(d => d.MyLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_MyFunLocation_MyLocationID");
        });

        modelBuilder.Entity<MyLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Locations_MyLocation");

            entity.ToTable("MyLocation", "Locations");

            entity.HasIndex(e => e.UserId, "IX_Locations_MyLocation_UserID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GeoPoint).HasColumnType("geometry");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.MyLocation)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_MyLocation_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Locations_User");

            entity.ToTable("User", "Locations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VFunLocationGeoPoint>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vFunLocationGeoPoint", "Locations");

            entity.Property(e => e.CoordinateId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CoordinateID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
