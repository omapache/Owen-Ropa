using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {

        builder.ToTable("orden");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Fecha)
        .HasColumnName("fecha")
        .HasColumnType("Date")
        .IsRequired();

        builder.HasOne(p => p.Empleado)
        .WithMany(p => p.Ordenes)
        .HasForeignKey(p => p.IdEmpleadoFk);

        builder.HasOne(p => p.Cliente)
        .WithMany(p => p.Ordenes)
        .HasForeignKey(p => p.IdClienteFk);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Ordenes)
        .HasForeignKey(p => p.IdEstadoFk);
    }
}