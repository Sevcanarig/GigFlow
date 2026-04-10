using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Commands.UpdateProposal
{
    public class UpdateProposalCommandValidator : AbstractValidator<UpdateProposalCommand>
    {
        public UpdateProposalCommandValidator()
        {
            RuleFor(x => x.CoverLetter).NotEmpty().MaximumLength(3000);
            RuleFor(x => x.ProposedAmount).GreaterThan(0);
            RuleFor(x => x.EstimatedDuration).GreaterThan(0);
        }
    }
}
