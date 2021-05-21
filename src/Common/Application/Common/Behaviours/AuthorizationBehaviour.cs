using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public AuthorizationBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                // Deve ser usuário autenticado
                if (_currentUserService.UserId == null)
                {
                    throw new UnauthorizedAccessException();
                }

                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        var authorized = false;
                        foreach (var role in roles)
                        {
                            var isInRole = await _identityService.UserIsInRole(_currentUserService.UserId, role.Trim());
                            if (!isInRole)
                                continue;
                            authorized = true;
                        }

                        // Deve ser membro de pelo menos uma role das roles
                        if (!authorized)
                        {
                            _logger.LogInformation("Ntitsolutions Authorization Request: {@UserId} {@Request}", _currentUserService.UserId, request);
                            throw new ForbiddenAccessException();
                        }
                    }
                }
            }

            // O usuário está autorizado / a autorização não é necessária
            return await next();
        }
    }
}