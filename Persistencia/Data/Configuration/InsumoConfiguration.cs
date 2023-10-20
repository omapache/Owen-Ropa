using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {

        builder.ToTable("insumo");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.ValorUnitario)
        .HasColumnName("valorUnitario")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.StockMinimo)
        .HasColumnName("stockMinimo")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.StockMaximo)
        .HasColumnName("stockMaximo")
        .HasColumnType("int")
        .IsRequired();



        
    }
}