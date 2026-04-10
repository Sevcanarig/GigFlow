using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<Contract> GetByProposalIdAsync(Guid proposalId);
        Task<List<Contract>> GetByFreelancerIdAsync(Guid freelancerId);
        Task<List<Contract>> GetByClientIdAsync(Guid clientId);
    }
}

