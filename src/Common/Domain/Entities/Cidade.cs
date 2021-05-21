using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cidade : AuditableEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
