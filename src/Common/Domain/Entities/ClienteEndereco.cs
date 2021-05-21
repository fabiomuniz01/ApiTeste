using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class ClienteEndereco : AuditableEntity
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdEndereco { get; set; }
        [ForeignKey("ID_CLIENTE")]
        public Cliente Cliente { get; set; }
        [ForeignKey("ID_ENDERECO")]
        public Endereco Endereco { get; set; }
    }
}
