using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ClienteEnderecoDto : IRegister
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdEndereco { get; set; }
        public ClienteDto ClienteDto { get; set; }
        public EnderecoDto EnderecoDto { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ClienteEndereco, ClienteEnderecoDto>();
        }
    }
}
