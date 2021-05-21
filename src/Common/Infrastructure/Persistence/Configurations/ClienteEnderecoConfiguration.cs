using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ClienteEnderecoConfiguration : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.ToTable("TB_CLIENTE_ENDERECO");

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.IdCliente)
                .HasColumnName("TB_CLIENTE_ID");

            builder.Property(t => t.IdEndereco)
                .HasColumnName("TB_ENDERECO_ID");

            //builder.Property(t => t.Endereco)
            //    .HasColumnName("ID_ENDERECO");

            //builder.Property(t => t.Cliente)
            //    .HasColumnName("ID_CLIENTE");

            //AuditableEntity
            builder.Property(p => p.CriadoPor).HasColumnName("NM_USU_INCLUSAO").HasMaxLength(256);
            builder.Property(p => p.DataCriacao).HasColumnName("DT_INCLUSAO");
            builder.Property(p => p.AlteradoPor).HasColumnName("NM_USU_ALTERACAO").HasMaxLength(256);
            builder.Property(p => p.DataAlteracao).HasColumnName("DT_ALTERACAO");
        }
    }
}
