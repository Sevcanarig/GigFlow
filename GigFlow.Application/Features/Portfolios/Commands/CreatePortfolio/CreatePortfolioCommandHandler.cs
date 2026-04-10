using AutoMapper;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, Guid>
    {
        private readonly IRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public CreatePortfolioCommandHandler(IRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            await _portfolioRepository.AddAsync(portfolio);
            await _portfolioRepository.SaveChangesAsync();
            return portfolio.Id;
        }
    }
}