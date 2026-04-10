using AutoMapper;

using GigFlow.Application.Features.Portfolios.Dtos;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Portfolios.Queries.GetPortfoliosByFreelancer
{
    public class GetPortfoliosByFreelancerQueryHandler : IRequestHandler<GetPortfoliosByFreelancerQuery, List<PortfolioDto>>
    {
        private readonly IRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public GetPortfoliosByFreelancerQueryHandler(IRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<List<PortfolioDto>> Handle(GetPortfoliosByFreelancerQuery request, CancellationToken cancellationToken)
        {
            var portfolios = await _portfolioRepository.GetWhereAsync(p => p.FreelancerId == request.FreelancerId);
            return _mapper.Map<List<PortfolioDto>>(portfolios);
        }
    }
}