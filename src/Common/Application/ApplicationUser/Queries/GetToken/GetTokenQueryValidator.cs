using FluentValidation;

namespace Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
    {
        public GetTokenQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("O e-mail não deve ter mais de 100 caracteres.")
                .NotEmpty().WithMessage("Email é obrigatório.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Senha é obrigatório.");
        }
    }
}
