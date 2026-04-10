using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Repositories
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(GigFlowDbContext context) : base(context)
        {
        }

        public async Task<List<Portfolio>> GetByFreelancerIdAsync(Guid freelancerId)
        {
            return await _dbSet
                .Where(p => p.FreelancerId == freelancerId)
                .ToListAsync();
        }
    }
}