using FluentValidation;

namespace GigFlow.Application.Features.Contracts.Commands.CreateContract;

public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor(x => x.ProposalId)
            .NotEmpty()
            .WithMessage("Teklif ID boş olamaz");
    }
}
