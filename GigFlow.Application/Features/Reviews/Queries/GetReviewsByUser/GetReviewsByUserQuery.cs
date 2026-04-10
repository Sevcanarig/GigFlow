using GigFlow.Application.Features.Reviews.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser
{
    public class GetReviewsByUserQuery : IRequest<List<ReviewDto>>
    {
        public Guid UserId { get; set; }
    }
}
