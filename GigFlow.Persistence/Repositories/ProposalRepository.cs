using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Repositories
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        public ProposalRepository(GigFlowDbContext context) : base(context)
        {
        }

        public async Task<Proposal?> GetByJobPostingAndFreelancer(Guid jobPostingId, Guid freelancerId)
        {
            return await _context.Set<Proposal>()
                                 .FirstOrDefaultAsync(p => p.JobPostingId == jobPostingId
                                                        && p.FreelancerId == freelancerId);
        }

        public async Task<List<Proposal>> GetByJobPosting(Guid jobPostingId)
        {
            return await _context.Set<Proposal>()
                                 .Where(p => p.JobPostingId == jobPostingId)
                                 .ToListAsync();
        }

        public async Task<List<Proposal>> GetByJobPostingExcludingProposal(Guid jobPostingId, Guid proposalId)
        {
            return await _context.Set<Proposal>()
                                 .Where(p => p.JobPostingId == jobPostingId && p.Id != proposalId)
                                 .ToListAsync();
        }
    }
}