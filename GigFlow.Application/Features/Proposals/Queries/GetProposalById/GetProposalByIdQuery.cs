using GigFlow.Application.Features.Proposals.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Queries.GetProposalById
{
    public class GetProposalByIdQuery : IRequest<ProposalDto>
    {
        public Guid Id { get; set; }
    }
}
