using GigFlow.Application.Features.Reviews.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract
{
    public class GetReviewsByContractQuery : IRequest<List<ReviewDto>>
    {
        public Guid ContractId { get; set; }
    }
}
