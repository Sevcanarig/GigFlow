using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus
{
    public class UpdateContractStatusCommand : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public ContractStatus Status { get; set; }
    }
}
