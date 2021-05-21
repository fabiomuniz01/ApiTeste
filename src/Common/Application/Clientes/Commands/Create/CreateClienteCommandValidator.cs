using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Commands.Create
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateClienteCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Cpf)
                .MustAsync(ValidaCpfCadastrado).WithMessage("O cpf especificado já existe.");
        }

        private async Task<bool> ValidaCpfCadastrado(string cpf, CancellationToken cancellationToken)
        {
            return await _context.Clientes.AllAsync(x => x.Cpf != cpf, cancellationToken);
        }
    }
}
