using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Queries.GetClienteByCidade
{
    public class GetClienteByCidadeQuery : IRequestWrapper<List<ClienteDto>>
    {
        public string Cidade { get; set; }
    }

    public class GetClienteByCidadeQueryHandler : IRequestHandlerWrapper<GetClienteByCidadeQuery, List<ClienteDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClienteByCidadeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ClienteDto>>> Handle(GetClienteByCidadeQuery request, CancellationToken cancellationToken)
        {
            var enderecos = await _context.Cidade
                .Where(c=>c.Nome==request.Cidade)
                .Select(s=>s.Enderecos)
                .ProjectToType<EnderecoDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            var listClientes = (enderecos.SelectMany(item => item.ClienteEnderecosDto.Select(s => s.ClienteDto).ToList())).ToList();
            
            return listClientes.Count > 0 ? ServiceResult.Success(listClientes) : ServiceResult.Failed<List<ClienteDto>>(ServiceError.NotFount);

        }
    }
}
