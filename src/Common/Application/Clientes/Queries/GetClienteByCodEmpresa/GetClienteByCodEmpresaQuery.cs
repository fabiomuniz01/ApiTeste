using Application.Common.Interfaces;
using Application.Dto;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clientes.Queries.GetClienteByCodEmpresa
{
    public class GetClienteByCodEmpresaQuery : IRequest<List<ClienteDapperDto>>
    {
        public string condicao { get; set; }

        public class GetClienteByCodEmpresaQueryHandler : IRequestHandler<GetClienteByCodEmpresaQuery, List<ClienteDapperDto>>
        {

            private readonly IDapperDbConnectionFactory _dapperDbConnectionFactory;
            private readonly IMapper _mapper;

            public GetClienteByCodEmpresaQueryHandler(IDapperDbConnectionFactory dapperDbConnectionFactory, IMapper mapper)
            {
                _dapperDbConnectionFactory = dapperDbConnectionFactory;
                _mapper = mapper;
            }

            public async Task<List<ClienteDapperDto>> Handle(GetClienteByCodEmpresaQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = string.Format(@"SELECT * FROM TB_CLIENTE WHERE {0}", request.condicao);
                    var responseModel = await _dapperDbConnectionFactory.GetDbConnection()
                                        .QueryAsync<ClienteDapperDto>(query);

                    return (List<ClienteDapperDto>)responseModel;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }
    }
}
