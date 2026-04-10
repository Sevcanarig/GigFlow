using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Commands.CreateContract
{
    public class CreateContractCommand : IRequest<Guid>
    {
        public Guid ProposalId { get; set; }
    }
}
