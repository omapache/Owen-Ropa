using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {

        builder.ToTable("cliente");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.IdCliente)
        .HasColumnName("idCliente")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Clientes)
        .HasForeignKey(p => p.IdTipoPersonaFk);

         builder.Property(p => p.FechaRegistro)
        .HasColumnName("fechaRegistro")
        .HasColumnType("Date")
        .IsRequired();

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Clientes)
        .HasForeignKey(p => p.IdMunicioFk);
       
    }
}

