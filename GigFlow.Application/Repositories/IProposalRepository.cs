using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Repositories
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Task<Proposal?> GetByJobPostingAndFreelancer(Guid jobPostingId, Guid freelancerId);
        Task<List<Proposal>> GetByJobPosting(Guid jobPostingId);
        Task<List<Proposal>> GetByJobPostingExcludingProposal(Guid jobPostingId, Guid proposalId);
    }
}
