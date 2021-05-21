using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cidade> Cidade { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CriadoPor = _currentUserService.UserId;
                        entry.Entity.DataCriacao = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.AlteradoPor = _currentUserService.UserId;
                        entry.Entity.DataAlteracao = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                .HasMany(c => c.ClienteEnderecos)
                .WithOne(e => e.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Endereco>()
                .HasMany(c => c.ClienteEnderecos)
                .WithOne(e => e.Endereco)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Endereco>()
                .HasMany(c => c.ClienteEnderecos)
                .WithOne(e => e.Endereco)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Cidade>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cidade)
                .OnDelete(DeleteBehavior.Cascade);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
