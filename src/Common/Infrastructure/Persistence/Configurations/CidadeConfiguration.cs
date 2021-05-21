using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("TB_CIDADE");

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME").HasMaxLength(100);

            builder.Property(t => t.Estado)
                .HasColumnName("ESTADO").HasMaxLength(2);

            //AuditableEntity
            builder.Property(p => p.CriadoPor).HasColumnName("NM_USU_INCLUSAO").HasMaxLength(256);
            builder.Property(p => p.DataCriacao).HasColumnName("DT_INCLUSAO");
            builder.Property(p => p.AlteradoPor).HasColumnName("NM_USU_ALTERACAO").HasMaxLength(256);
            builder.Property(p => p.DataAlteracao).HasColumnName("DT_ALTERACAO");
        }
    }
}
