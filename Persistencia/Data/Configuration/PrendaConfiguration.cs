using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {

        builder.ToTable("prenda");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.IdPrenda)
        .HasColumnName("idPrenda")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.ValorUnitCop)
        .HasColumnName("valorUnitCop")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.ValorUnitUsd)
        .HasColumnName("valorUnitUsd")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdEstadoFk);

        builder.HasOne(p => p.TipoProteccion)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdTipoProteccionFk);

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdGeneroFk);
    }
}