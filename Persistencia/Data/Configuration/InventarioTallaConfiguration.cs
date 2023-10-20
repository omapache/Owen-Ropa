using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {

        builder.ToTable("inventarioTalla");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        
        .IsRequired();

        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdInventarioFk);

        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdInventarioFk);
        
    }
}