using GigFlow.Application.Features.Reviews.Dtos;
using MediatR;
using System;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<ReviewDto>
    {
        public Guid ContractId { get; set; }
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}