using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
