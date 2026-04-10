using GigFlow.Application.Features.Proposals.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting
{
    public class GetProposalsByJobPostingQuery : IRequest<List<ProposalDto>>
    {
        public Guid JobPostingId { get; set; }
    }
}
