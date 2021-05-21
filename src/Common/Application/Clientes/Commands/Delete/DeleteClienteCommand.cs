using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Commands.Delete
{
    public class DeleteClienteCommand : IRequestWrapper<ClienteDto>
    {
        public int Id { get; set; }
    }

    public class DeleteClienteCommandHandler : IRequestHandlerWrapper<DeleteClienteCommand, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteClienteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClienteDto>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clientes
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Id);
            }

            _context.Clientes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ClienteDto>(entity));
        }
    }
}
