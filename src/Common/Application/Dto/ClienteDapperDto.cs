using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ClienteDapperDto 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }
    }
}
