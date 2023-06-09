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
        => optionsBuilder.UseMySql(WebApplication.CreateBuilder().Configuration.GetConnectionString("tacosdb"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));


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

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
