using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.TaxaJuros.Queries.GetTaxaJuros
{
    public class GetTaxaJurosQuery : IRequestWrapper<decimal>
    {

    }

    public class GetTaxaJurosQueryHandler : IRequestHandlerWrapper<GetTaxaJurosQuery, decimal>
    {
        public async Task<ServiceResult<decimal>> Handle(GetTaxaJurosQuery request, CancellationToken cancellationToken)
        {
            var taxa = 0.01m;
            return taxa > 0 ? ServiceResult.Success(0.01m) : ServiceResult.Failed<decimal>(ServiceError.NotFount);
        }
    }
}
