using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.TaxaJuros.Queries.GetCalculoJuros
{
    public class GetCalculoJurosQuery : IRequestWrapper<string>
    {
        public int valorinicial { get; set; }
        public decimal juros { get; set; }
        public int Tempo { get; set; }
    }

    public class GetCalculoJurosQueryHandler : IRequestHandlerWrapper<GetCalculoJurosQuery, string>
    {
        public async Task<ServiceResult<string>> Handle(GetCalculoJurosQuery request, CancellationToken cancellationToken)
        {
            var valorFinal = request.valorinicial * (decimal)Math.Pow(Convert.ToDouble((1 + request.juros)), request.Tempo);

            return valorFinal > 0 ? ServiceResult.Success(string.Format("{0:0.00}", valorFinal)) : ServiceResult.Failed<string>(ServiceError.NotFount);
        }
    }
}
