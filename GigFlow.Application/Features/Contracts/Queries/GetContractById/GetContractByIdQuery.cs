using GigFlow.Application.Features.Contracts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractById
{
    public class GetContractByIdQuery : IRequest<ContractDto>
    {
        public Guid Id { get; set; }
    }
}
