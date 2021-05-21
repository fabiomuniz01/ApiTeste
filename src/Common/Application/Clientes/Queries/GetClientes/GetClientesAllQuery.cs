using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Queries.GetClientes
{
    public class GetClientesAllQuery : IRequestWrapper<List<ClienteDto>>
    {

    }

    public class GetClientesQueryHandler : IRequestHandlerWrapper<GetClientesAllQuery, List<ClienteDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClientesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ClienteDto>>> Handle(GetClientesAllQuery request, CancellationToken cancellationToken)
        {
            List<ClienteDto> list = await _context.Clientes
                .Include(x => x.ClienteEnderecos)
                .ThenInclude(c => c.Endereco)
                .ProjectToType<ClienteDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ClienteDto>>(ServiceError.NotFount);
        }
    }
}
