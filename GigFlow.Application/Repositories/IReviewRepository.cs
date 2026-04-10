using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GigFlow.Application.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<List<Review>> GetReviewsByContractIdAsync(Guid contractId);
        Task<List<Review>> GetReviewsByUserIdAsync(Guid userId);
    }
}