using System;

namespace Application.Common.Exceptions
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException() : base("Usuário não encontrado!")
        {
            
        }
    }
}
