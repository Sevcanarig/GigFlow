using GigFlow.Application.Features.Contracts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer
{
    public class GetContractsByFreelancerQuery : IRequest<List<ContractDto>>
    {
        public Guid FreelancerId { get; set; }
    }
}
