using AutoMapper;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.UpdatePortfolio
{
    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand,Unit>
    {
        private readonly IRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public UpdatePortfolioCommandHandler(IRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(request.Id);
            if (portfolio == null)
                throw new KeyNotFoundException("Portfolio not found");

            _mapper.Map(request, portfolio);

            _portfolioRepository.Update(portfolio);
            await _portfolioRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}