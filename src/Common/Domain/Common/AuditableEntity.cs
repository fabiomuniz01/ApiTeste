using System;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CriadoPor { get; set; }

        public DateTime DataCriacao { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime? DataAlteracao { get; set; }

    }
}
