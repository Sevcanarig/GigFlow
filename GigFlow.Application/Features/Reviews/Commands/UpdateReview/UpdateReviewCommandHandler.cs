using GigFlow.Application.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand , Unit>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.Id);
            if (review == null) throw new Exception("Review not found");

            review.Rating = request.Rating;
            review.Comment = request.Comment;

            _reviewRepository.Update(review);
            await _reviewRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}