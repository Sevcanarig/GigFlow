using FluentValidation;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(r => r.ContractId).NotEmpty();
            RuleFor(r => r.ReviewerId).NotEmpty();
            RuleFor(r => r.RevieweeId).NotEmpty();
            RuleFor(r => r.Rating).InclusiveBetween(1, 5);
            RuleFor(r => r.Comment).NotEmpty().MaximumLength(2000);
        }
    }
}