using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequestWrapper<ClienteDto>
    {
        public int ClienteId { get; set; }
    }

    public class GetClienteByIdQueryHandler : IRequestHandlerWrapper<GetClienteByIdQuery, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClienteDto>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var Cliente = await _context.Clientes
                .Where(x => x.Id == request.ClienteId)
                .Include(d => d.ClienteEnderecos)
                .ThenInclude(v => v.Endereco)
                .ProjectToType<ClienteDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return Cliente != null ? ServiceResult.Success(Cliente) : ServiceResult.Failed<ClienteDto>(ServiceError.NotFount);
        }
    }
}
