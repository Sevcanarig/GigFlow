using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Repositories
{
    public interface IMilestoneRepository : IRepository<Milestone>
    {
        Task<Milestone?> GetByIdAsync(Guid id);
        Task<List<Milestone>> GetByContractIdAsync(Guid contractId);
    }
}
