using System;

namespace Application.Common.Models
{
    /// <summary>
    /// Todos os erros contidos em objetos ServiceResult devem retornar um erro deste tipo
    /// Os códigos de erro permitem que o chamador identifique facilmente o erro recebido e execute uma ação.
    /// Mensagens de erro permitem que o chamador mostre facilmente mensagens de erro ao usuário final.
    /// </summary>
    [Serializable]
    public class ServiceError
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ServiceError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }

        public ServiceError() { }

        /// <summary>
        /// Mensagem de erro legível por usuários
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Código de erro legível por aplicação
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Erro padrão para quando recebemos uma exceção
        /// </summary>
        public static ServiceError DefaultError => new ServiceError("Ocorreu uma exceção.", 999);

        /// <summary>
        /// Erro de validação padrão. Use isso para parâmetros inválidos em ações do controlador e métodos de serviço.
        /// </summary>
        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, 998);
        }

        /// <summary>
        /// ServiceError para respostas não autorizadas.
        /// </summary>
        public static ServiceError ForbiddenError => new ServiceError("Você não está autorizado a chamar esta ação.", 998);

        /// <summary>
        /// Use para enviar uma mensagem de erro personalizada
        /// </summary>
        public static ServiceError CustomMessage(string errorMessage)
        {
            return new ServiceError(errorMessage, 997);
        }

        public static ServiceError UserNotFound => new ServiceError("O usuário com este id não existe", 996);

        public static ServiceError UserFailedToCreate => new ServiceError("Falha ao criar usuário.", 995);

        public static ServiceError Canceled => new ServiceError("O pedido foi cancelado com sucesso!", 994);

        public static ServiceError NotFount => new ServiceError("O recurso especificado não foi encontrado.", 990);

        public static ServiceError ValidationFormat => new ServiceError("O formato do objeto de solicitação é inválido.", 901);
        
        public static ServiceError Validation => new ServiceError("Ocorreram um ou mais erros de validação.", 900);

        public static ServiceError SearchAtLeastOneCharacter => new ServiceError("O parâmetro de pesquisa deve ter pelo menos um caractere!", 898);

        /// <summary>
        /// Erro padrão para quando recebemos uma exceção
        /// </summary>
        public static ServiceError ServiceProviderNotFound => new ServiceError("O provedor de serviços com este nome não existe.", 700);

        public static ServiceError ServiceProvider => new ServiceError("O provedor de serviços não retornou conforme o esperado.", 600);

        public static ServiceError DateTimeFormatError => new ServiceError("O formato da data não é inválido. O formato da data deve ser dd/MM/yyyy (06/03/2021)", 500);

        #region Override Operador Equals

        /// <summary>
        /// Use isto para comparar se dois erros são iguais
        /// </summary>
        public override bool Equals(object obj)
        {
            // Se o parâmetro não puder ser convertido em ServiceError ou for nulo, retorne falso.
            var error = obj as ServiceError;

            // Retorna verdadeiro se os códigos de erro corresponderem. Falso se o objeto com o qual estamos comparando for nulo
            // ou se tiver um código diferente.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Retorna verdadeiro se os códigos de erro corresponderem. Falso se o objeto com o qual estamos comparando for nulo
            // ou se tiver um código diferente.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            // Se ambos forem nulos, ou ambos forem a mesma instância, retorna verdadeiro.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // Se um for nulo, mas não ambos, retorna falso.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            // Retorna verdadeiro se os campos corresponderem:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }

}
