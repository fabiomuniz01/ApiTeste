using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Clientes.Commands;
using Application.Clientes.Commands.Create;
using Application.Clientes.Commands.Delete;
using Application.Clientes.Commands.Update;
using Application.Clientes.Queries.GetClienteByCidade;
using Application.Clientes.Queries.GetClienteByCodEmpresa;
using Application.Clientes.Queries.GetClienteById;
using Application.Common.Models;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ClienteController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ClienteDto>>>> GetClienteAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetClienteAllQuery(), cancellationToken));
        }

        [HttpGet("{cidade}")]
        public async Task<ActionResult<ServiceResult<List<ClienteDto>>>> GetCityById(string cidade)
        {
            return Ok(await Mediator.Send(new GetClienteByCidadeQuery { Cidade = cidade }));
        }

        [HttpGet("{codEmpresa}")]
        public async Task<ActionResult<ServiceResult<List<ClienteDto>>>> GetClienteByCodEmpresa(int codEmpresa)
        {
            return Ok(await Mediator.Send(new GetClienteByCodEmpresaQuery 
                                                { 
                                                    condicao = string.Format(@"COD_EMPRESA = '{0}'",codEmpresa) 
                                                }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<ClienteDto>>> GetClienteById(int id)
        {
            return Ok(await Mediator.Send(new GetClienteByIdQuery { ClienteId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<ClienteDto>>> Create(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<ClienteDto>>> Update(UpdateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<ClienteDto>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClienteCommand { Id = id }));
        }

    }
}
