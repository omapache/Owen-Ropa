using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {

        builder.ToTable("empresa");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Nit)
        .HasColumnName("nit")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.RazonSocial)
        .HasColumnName("razonSocial")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.RepresentanteLegal)
        .HasColumnName("representanteLegal")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();
        
        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Empresas)
        .HasForeignKey(p => p.IdMunicioFk);

        builder.Property(p => p.FechaCreacion)
        .HasColumnName("fechaCreacion")
        .HasColumnType("Date")
        .IsRequired();

    }
}