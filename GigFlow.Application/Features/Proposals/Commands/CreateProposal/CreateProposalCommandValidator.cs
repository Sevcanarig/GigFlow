using FluentValidation;
using GigFlow.Application.Features.Proposals.Commands.CreateProposal;

public class CreateProposalCommandValidator : AbstractValidator<CreateProposalCommand>
{
    public CreateProposalCommandValidator()
    {
        RuleFor(x => x.CoverLetter)
            .NotEmpty()
            .MaximumLength(3000);

        RuleFor(x => x.ProposedAmount)
            .GreaterThan(0);

        RuleFor(x => x.EstimatedDuration)
            .GreaterThan(0);
    }
}