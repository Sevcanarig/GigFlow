using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Commands.AcceptProposal
{
    public class AcceptProposalCommand : IRequest<Unit>
    {
        public Guid ProposalId { get; set; }
    }
}
