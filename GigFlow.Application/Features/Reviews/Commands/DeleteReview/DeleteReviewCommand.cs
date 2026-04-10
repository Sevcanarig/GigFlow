using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest <Unit>
    {
        public Guid Id { get; set; }
    }
}
