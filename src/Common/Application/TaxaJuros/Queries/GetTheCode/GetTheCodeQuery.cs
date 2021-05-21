using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.TaxaJuros.Queries.GetTheCode
{
    public class GetTheCodeQuery : IRequestWrapper<string>
    {

    }

    public class GetTheCodeQueryHandler : IRequestHandlerWrapper<GetTheCodeQuery, string>
    {
        public async Task<ServiceResult<string>> Handle(GetTheCodeQuery request, CancellationToken cancellationToken)
        {
            var git = "https://github.com/fabiomuniz01/ApiTeste.git";
            return git != string.Empty ? ServiceResult.Success(git) : ServiceResult.Failed<string>(ServiceError.NotFount);
        }
    }
}
