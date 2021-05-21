using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.TaxaJuros.Queries.GetCalculoJuros;
using Application.TaxaJuros.Queries.GetTaxaJuros;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("")]
    public class CalculoJurosController : BaseApiController
    {
        
        [HttpGet("calculajuros/{valorInicial}/{meses}")]
        public async Task<ActionResult<ServiceResult<string>>> GetCalculoJuros(int valorInicial, int meses, CancellationToken cancellationToken)
        {
            var juros = await Mediator.Send(new GetTaxaJurosQuery(), cancellationToken);
            return Ok(await Mediator.Send(new GetCalculoJurosQuery(){juros=juros.Data, Tempo = meses, valorinicial = valorInicial}, cancellationToken));
        }

    }
}
