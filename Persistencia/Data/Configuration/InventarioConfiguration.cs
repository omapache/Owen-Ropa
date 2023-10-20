using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {

        builder.ToTable("inventario");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.CodigoInventario)
        .HasColumnName("codigoInventario")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.Inventarios)
        .HasForeignKey(p => p.IdPrendaFK);

        builder.Property(p => p.ValorVentaCop)
        .HasColumnName("valorVentaCop")
        .HasColumnType("double")
        .IsRequired();

        builder.Property(p => p.ValorVentaUsd)
        .HasColumnName("valorVentaUsd")
        .HasColumnType("double")
        .IsRequired();
    }
}