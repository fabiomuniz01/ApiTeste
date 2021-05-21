using System;
using FluentAssertions;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Domain.Entities;
using Application.Dto;

namespace OpahIT.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            TypeAdapterConfig typeAdapterConfig = new TypeAdapterConfig();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            _mapper = scope.ServiceProvider.GetService<IMapper>();
        }


        [Test]
        [TestCase(typeof(Cliente), typeof(ClienteDto))]
        public void MapeamentoDaOrigemParaDestino(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }

        [Test]
        public void MapearCorretamente()
        {
            var cliente = new Cliente { Id = 1, Rg = "4512781" };
            var clienteDto = _mapper.Map<Cliente, ClienteDto>(cliente);
            clienteDto.Rg.Should().Be("4512781");
        }
    }
}
