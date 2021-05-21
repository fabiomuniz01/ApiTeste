using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class CidadeDto : IRegister
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public ICollection<EnderecoDto> Enderecos { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Cidade, CidadeDto>();
        }
    }
}
