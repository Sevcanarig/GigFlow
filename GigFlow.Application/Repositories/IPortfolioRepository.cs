using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Repositories
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
        Task<List<Portfolio>> GetByFreelancerIdAsync(Guid freelancerId);
    }
}
