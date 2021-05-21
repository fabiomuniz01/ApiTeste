using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Queries.GetClienteByCpf
{
    public class GetClienteByCpfQuery : IRequestWrapper<ClienteDto>
    {
        public string Cpf { get; set; }
    }

    public class GetClienteByCpfQueryHandler : IRequestHandlerWrapper<GetClienteByCpfQuery, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClienteByCpfQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClienteDto>> Handle(GetClienteByCpfQuery request, CancellationToken cancellationToken)
        {
            var Cliente = await _context.Clientes
                .Where(x => x.Cpf == request.Cpf)
                .Include(x => x.ClienteEnderecos)
                .ThenInclude(c => c.Endereco)
                .ProjectToType<ClienteDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return Cliente != null ? ServiceResult.Success(Cliente) : ServiceResult.Failed<ClienteDto>(ServiceError.NotFount);
        }
    }
}
