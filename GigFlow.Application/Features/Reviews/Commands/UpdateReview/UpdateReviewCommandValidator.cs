using FluentValidation;

namespace GigFlow.Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Rating).InclusiveBetween(1, 5);
            RuleFor(r => r.Comment).NotEmpty().MaximumLength(2000);
        }
    }
}