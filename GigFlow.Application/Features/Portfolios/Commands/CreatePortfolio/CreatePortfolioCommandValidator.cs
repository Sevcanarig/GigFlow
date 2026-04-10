using FluentValidation;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
    {
        public CreatePortfolioCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(3000);
            RuleFor(x => x.ProjectUrl).MaximumLength(500);
            RuleFor(x => x.ImageUrl).MaximumLength(500);
        }
    }
}