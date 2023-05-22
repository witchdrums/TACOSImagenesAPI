using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TACOSImagenesAPI.Modelos;

public partial class TacosimagenesContext : DbContext
{
    public TacosimagenesContext()
    {
    }

    public TacosimagenesContext(DbContextOptions<TacosimagenesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagen> Imagenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=tacosdb;uid=tacosUser;pwd=T4C05", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imagenes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagenBytes).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
