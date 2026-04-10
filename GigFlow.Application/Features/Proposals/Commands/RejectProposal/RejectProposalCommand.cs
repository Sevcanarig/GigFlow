using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Commands.RejectProposal
{
    public class RejectProposalCommand : IRequest<Unit>
    {
        public Guid ProposalId { get; set; }
    }
}
