using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GigFlow.Persistence.Repositories
{
    public class MilestoneRepository : Repository<Milestone>, IMilestoneRepository
    {
        private readonly GigFlowDbContext _context;

        public MilestoneRepository(GigFlowDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Milestone?> GetByIdAsync(Guid id)
        {
            return await _context.Milestones
                                 .Include(m => m.Contract)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Milestone>> GetByContractIdAsync(Guid contractId)
        {
            return await _context.Milestones
                                 .Where(m => m.ContractId == contractId)
                                 .OrderBy(m => m.Order)
                                 .ToListAsync();
        }
    }
}
    