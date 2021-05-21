using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Commands.Update
{
    public class UpdateClienteCommand : IRequestWrapper<ClienteDto>
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

    public class UpdateClienteCommandHandler : IRequestHandlerWrapper<UpdateClienteCommand, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClienteDto>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            //Incluir validação antes de realizar as alterações se o cliente que está sendo alterado existe na base;
            var entity = await _context.Clientes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Id);
            }
            if (!string.IsNullOrEmpty(request.Cpf))
            {
                entity.Nome = request.Nome;
                entity.Rg = request.Rg;
                entity.DataNascimento = request.DataNascimento;
                entity.Telefone = request.Telefone;
                entity.Email = request.Email;
                entity.CodEmpresa = request.CodEmpresa;

            }

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ClienteDto>(entity));
        }
    }
}
