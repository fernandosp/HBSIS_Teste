using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using FSP.HBSIS.Domain.Entities;

namespace FSP.HBSIS.Infra.Data.EntityConfig
{
    // Fluent API
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);
            //HasKey(c => new {c.ClienteId, c.CPF});

            Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute() {IsUnique = true}));

            Property(c => c.Telefone)
               .IsRequired()
               .HasMaxLength(20)
               .HasColumnType("varchar");

            Property(c => c.Ativo)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Clientes");
        }
    }
}