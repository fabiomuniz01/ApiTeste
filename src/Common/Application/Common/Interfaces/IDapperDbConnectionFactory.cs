using System.Data;

namespace Application.Common.Interfaces
{
    public interface IDapperDbConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
