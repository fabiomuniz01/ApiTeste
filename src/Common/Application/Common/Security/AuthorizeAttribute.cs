using System;

namespace Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AuthorizeAttribute"/>. 
        /// </summary>
        public AuthorizeAttribute() { }

        /// <summary>
        /// Obtém ou define uma lista delimitada por vírgulas que têm permissão para acessar o recurso.
        /// </summary>
        public string Roles { get; set; }
    }
}
