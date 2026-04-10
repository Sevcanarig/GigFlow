using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;

namespace GigFlow.Application.Repositories
{
    public interface IJobPostingRepository : IRepository<JobPosting>
    {

        Task<List<JobPosting>> GetAllAsync();
        Task<JobPosting> GetByIdAsync(Guid id);
        Task<JobPosting> GetByIdWithSkillsAsync(Guid id);
        Task<List<JobPosting>> GetByCategoryIdAsync(Guid categoryId);
        Task AddAsync(JobPosting entity);
        Task UpdateAsync(JobPosting entity);
        void Delete(JobPosting entity);
        Task SaveChangesAsync();
    }
    }
