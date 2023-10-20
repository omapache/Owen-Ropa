using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {

        builder.ToTable("detalleOrden");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.IdDetalleOrden)
        .HasColumnName("idDetalleOrden")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdPrendaFk);

        builder.HasOne(p => p.Color)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdColorFk);

        builder.Property(p => p.CantidadProducida)
        .HasColumnName("cantidadProducida")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdEstadoFk);
    }
}
