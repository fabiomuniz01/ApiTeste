using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class EnderecoDto : IRegister
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int TipoEndereco { get; set; }
        public ICollection<ClienteEnderecoDto> ClienteEnderecosDto { get; set; }
        public CidadeDto CidadeDto { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Endereco, EnderecoDto>();
        }
    }
}
