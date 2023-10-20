using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {

        builder.ToTable("insumoPrenda");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Insumo)
        .WithMany(p => p.InsumoPrendas)
        .HasForeignKey(p => p.IdInsumoFk);

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.InsumoPrendas)
        .HasForeignKey(p => p.IdPrendaFk);
    }
}