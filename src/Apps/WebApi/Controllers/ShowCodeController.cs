using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.TaxaJuros.Queries.GetTheCode;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("")]
    public class ShowCodeController : BaseApiController
    {
        
        [HttpGet("showmethecode")]
        public async Task<ActionResult<ServiceResult<string>>> GetTheCode(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTheCodeQuery(), cancellationToken));
        }

    }
}
