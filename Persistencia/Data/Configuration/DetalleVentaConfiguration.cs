using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleVentaConfiguration  : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {

        builder.ToTable("detalleVenta");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.IdDetalleVenta)
        .HasColumnName("idDetalleVenta")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Venta)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdVentaFk);

        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdVentaFk);

        builder.Property(p => p.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.ValorUnitario)
        .HasColumnName("valorUnitario")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Talla)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdTallaFk);
    }
}