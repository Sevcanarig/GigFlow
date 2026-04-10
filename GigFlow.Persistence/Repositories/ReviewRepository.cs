using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(GigFlowDbContext context) : base(context)
        {
        }

        public async Task<List<Review>> GetReviewsByContractIdAsync(Guid contractId)
        {
            return await _context.Set<Review>()
                                 .Where(r => r.ContractId == contractId)
                                 .Include(r => r.Contract)
                                 .ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByUserIdAsync(Guid userId)
        {
            return await _context.Set<Review>()
                                 .Where(r => r.ReviewerId == userId || r.RevieweeId == userId)
                                 .Include(r => r.Contract)
                                 .ToListAsync();
        }
    }
}