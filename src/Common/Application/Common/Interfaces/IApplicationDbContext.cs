using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        DbSet<Endereco> Endereco { get; set; }
        DbSet<Cidade> Cidade { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
