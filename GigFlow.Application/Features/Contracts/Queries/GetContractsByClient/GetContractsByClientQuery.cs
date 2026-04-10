using GigFlow.Application.Features.Contracts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByClient
{
    public class GetContractsByClientQuery : IRequest<List<ContractDto>>
    {
        public Guid ClientId { get; set; }
    }
}
