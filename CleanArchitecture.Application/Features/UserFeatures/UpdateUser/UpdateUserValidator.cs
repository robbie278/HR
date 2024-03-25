using FluentValidation;

namespace CleanArchitecture.Application.Features.UserFeatures.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        
    }
}