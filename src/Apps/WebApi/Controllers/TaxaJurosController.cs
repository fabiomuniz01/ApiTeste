using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.TaxaJuros.Queries.GetTaxaJuros;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("")]
    public class TaxaJurosController : BaseApiController
    {
        [HttpGet("taxaJuros")]
        public async Task<ActionResult<ServiceResult<decimal>>> GetTaxaJuros(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTaxaJurosQuery(), cancellationToken));
        }

    }
}
