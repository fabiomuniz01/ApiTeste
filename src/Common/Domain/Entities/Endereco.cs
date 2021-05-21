using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Endereco : AuditableEntity
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int TipoEndereco { get; set; }
        public ICollection<ClienteEndereco> ClienteEnderecos { get; set; }
        [ForeignKey("ID_CIDADE")]
        public Cidade Cidade { get; set; }
    }
}
