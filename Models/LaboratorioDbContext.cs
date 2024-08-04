using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioManagerAPI.Models;

public partial class LaboratorioDbContext : DbContext
{
    public LaboratorioDbContext()
    {
    }

    public LaboratorioDbContext(DbContextOptions<LaboratorioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cientifico> Cientificos { get; set; }

    public virtual DbSet<CientificosXexperimento> CientificosXexperimentos { get; set; }

    public virtual DbSet<Experimento> Experimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8CP6FGQ\\SQLEXPRESS;Initial Catalog=LaboratorioDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cientifico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cientifi__3214EC077EFC21BD");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<CientificosXexperimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cientifi__3214EC07DFB4E489");

            entity.ToTable("CientificosXExperimento");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Cientifico).WithMany(p => p.CientificosXexperimentos)
                .HasForeignKey(d => d.CientificoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cientific__Cient__3E52440B");

            entity.HasOne(d => d.Experimento).WithMany(p => p.CientificosXexperimentos)
                .HasForeignKey(d => d.ExperimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cientific__Exper__3F466844");
        });

        modelBuilder.Entity<Experimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experime__3214EC07029D1DF0");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
