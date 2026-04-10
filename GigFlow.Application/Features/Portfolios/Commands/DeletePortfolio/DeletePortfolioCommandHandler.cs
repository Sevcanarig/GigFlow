using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand,Unit>
    {
        private readonly IRepository<Portfolio> _portfolioRepository;

        public DeletePortfolioCommandHandler(IRepository<Portfolio> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<Unit> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(request.Id);
            if (portfolio == null)
                throw new KeyNotFoundException("Portfolio not found");

            _portfolioRepository.Delete(portfolio);
            await _portfolioRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}