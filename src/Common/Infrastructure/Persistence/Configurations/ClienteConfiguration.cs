using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME").HasMaxLength(150);

            builder.Property(t => t.Rg)
                .HasColumnName("RG").HasMaxLength(20);

            builder.Property(t => t.Cpf)
                .HasColumnName("CPF").HasMaxLength(20);

            builder.Property(t => t.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO");

            builder.Property(t => t.Telefone)
                .HasColumnName("TELEFONE").HasMaxLength(20);

            builder.Property(t => t.Email)
                .HasColumnName("EMAIL_").HasMaxLength(20);

            builder.Property(t => t.CodEmpresa)
                .HasColumnName("COD_EMPRESA");

            //AuditableEntity
            builder.Property(p => p.CriadoPor).HasColumnName("NM_USU_INCLUSAO").HasMaxLength(256);
            builder.Property(p => p.DataCriacao).HasColumnName("DT_INCLUSAO");
            builder.Property(p => p.AlteradoPor).HasColumnName("NM_USU_ALTERACAO").HasMaxLength(256);
            builder.Property(p => p.DataAlteracao).HasColumnName("DT_ALTERACAO");
        }
    }
}
