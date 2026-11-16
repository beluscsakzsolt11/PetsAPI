using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PetsAPI.Models;

public partial class PetsContext : DbContext
{
    public PetsContext()
    {
    }

    public PetsContext(DbContextOptions<PetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fajtum> Fajta { get; set; }

    public virtual DbSet<Gazdum> Gazda { get; set; }

    public virtual DbSet<Kutya> Kutyas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=pets;user=root;ssl mode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Fajtum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fajta");

            entity.HasIndex(e => e.Megnevezes, "Megnevezes").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.EletAlso).HasColumnType("int(11)");
            entity.Property(e => e.EletFelso).HasColumnType("int(11)");
            entity.Property(e => e.Kategoria).HasMaxLength(32);
            entity.Property(e => e.Megnevezes).HasMaxLength(64);
            entity.Property(e => e.Meret).HasMaxLength(32);
            entity.Property(e => e.Szarmazas).HasMaxLength(64);
        });

        modelBuilder.Entity<Gazdum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gazda");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nev).HasMaxLength(64);
            entity.Property(e => e.Tel).HasMaxLength(16);
        });

        modelBuilder.Entity<Kutya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kutya");

            entity.HasIndex(e => e.FajtaId, "FajtaId");

            entity.HasIndex(e => e.GazdaId, "GazdaId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Eletkor).HasColumnType("int(11)");
            entity.Property(e => e.FajtaId).HasColumnType("int(11)");
            entity.Property(e => e.GazdaId).HasColumnType("int(11)");
            entity.Property(e => e.Nev).HasMaxLength(32);

            entity.HasOne(d => d.Fajta).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.FajtaId)
                .HasConstraintName("kutya_ibfk_1");

            entity.HasOne(d => d.Gazda).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.GazdaId)
                .HasConstraintName("kutya_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
