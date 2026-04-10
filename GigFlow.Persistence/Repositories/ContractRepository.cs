using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GigFlow.Persistence.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(GigFlowDbContext context) : base(context)
        {
        }

        public async Task<Contract> GetByProposalIdAsync(Guid proposalId)
        {
            return await _context.Contracts
                .Include(c => c.Milestones)
                .Include(c => c.Reviews)
                .FirstOrDefaultAsync(c => c.ProposalId == proposalId);
        }

        public async Task<List<Contract>> GetByFreelancerIdAsync(Guid freelancerId)
        {
            return await _context.Contracts
                .Where(c => c.FreelancerId == freelancerId)
                .Include(c => c.Milestones)
                .Include(c => c.Reviews)
                .ToListAsync();
        }

        public async Task<List<Contract>> GetByClientIdAsync(Guid clientId)
        {
            return await _context.Contracts
                .Where(c => c.ClientId == clientId)
                .Include(c => c.Milestones)
                .Include(c => c.Reviews)
                .ToListAsync();
        }
    }
}