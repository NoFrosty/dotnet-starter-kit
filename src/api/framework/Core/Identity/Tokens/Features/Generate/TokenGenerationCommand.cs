using System.ComponentModel;
using FluentValidation;
using FSH.Framework.Core.Tenant;

namespace FSH.Framework.Core.Identity.Tokens.Features.Generate;
public record TokenGenerationCommand(
    [property: DefaultValue(TenantConstants.Root.UserName)] string UserName,
    [property: DefaultValue(TenantConstants.DefaultPassword)] string Password);

public class GenerateTokenValidator : AbstractValidator<TokenGenerationCommand>
{
    public GenerateTokenValidator()
    {
        RuleFor(p => p.UserName).Cascade(CascadeMode.Stop).NotEmpty();

        RuleFor(p => p.Password).Cascade(CascadeMode.Stop).NotEmpty();
    }
}
