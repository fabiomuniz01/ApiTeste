using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Commands.Create
{
    public class CreateClienteCommand : IRequestWrapper<ClienteDto>
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandlerWrapper<CreateClienteCommand, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClienteDto>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Cliente
            {
                Nome= request.Nome,
                Rg = request.Rg,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento,
                Telefone = request.Telefone,
                Email = request.Email,
                CodEmpresa = request.CodEmpresa,
            };

            await _context.Clientes.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ClienteDto>(entity));
        }
    }
}
