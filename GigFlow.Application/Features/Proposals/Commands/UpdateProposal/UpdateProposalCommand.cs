using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Commands.UpdateProposal
{
    public class UpdateProposalCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string CoverLetter { get; set; }
        public decimal ProposedAmount { get; set; }
        public int EstimatedDuration { get; set; }
    }
}
