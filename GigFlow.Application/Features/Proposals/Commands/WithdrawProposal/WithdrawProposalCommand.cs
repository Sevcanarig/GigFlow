using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Commands.WithdrawProposal
{
    using MediatR;

    public class WithdrawProposalCommand : IRequest<Unit>
    {
        public Guid ProposalId { get; set; }
    }
}
