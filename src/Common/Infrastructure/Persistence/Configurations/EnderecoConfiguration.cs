using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECO");

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Rua)
                .HasColumnName("RUA").HasMaxLength(255);

            builder.Property(t => t.Bairro)
                .HasColumnName("BAIRRO").HasMaxLength(50);

            builder.Property(t => t.Numero)
                .HasColumnName("NUMERO").HasMaxLength(50);

            builder.Property(t => t.Complemento)
                .HasColumnName("COMPLEMENTO").HasMaxLength(100);

            builder.Property(t => t.Cep)
                .HasColumnName("CEP").HasMaxLength(10);

            builder.Property(t => t.TipoEndereco)
                .HasColumnName("TIPO_ENDERECO");

            //builder.Property(t => t.Cidade)
            //    .HasColumnName("ID_CIDADE");

            //AuditableEntity
            builder.Property(p => p.CriadoPor).HasColumnName("NM_USU_INCLUSAO").HasMaxLength(256);
            builder.Property(p => p.DataCriacao).HasColumnName("DT_INCLUSAO");
            builder.Property(p => p.AlteradoPor).HasColumnName("NM_USU_ALTERACAO").HasMaxLength(256);
            builder.Property(p => p.DataAlteracao).HasColumnName("DT_ALTERACAO");
        }
    }
}
