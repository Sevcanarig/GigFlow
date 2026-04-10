using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GigFlow.Persistence.Repositories
{
    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly GigFlowDbContext _context;

        public JobPostingRepository(GigFlowDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobPosting>> GetAllAsync()
        {
            return await _context.JobPostings
                                 .Include(j => j.Category)
                                 .ToListAsync();
        }

        public async Task<JobPosting> GetByIdAsync(Guid id)
        {
            return await _context.JobPostings
                                 .Include(j => j.Category)
                                 .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<JobPosting> GetByIdWithSkillsAsync(Guid id)
        {
            return await _context.JobPostings
                                 .Include(j => j.JobPostingSkills)
                                     .ThenInclude(jps => jps.Skill)
                                 .Include(j => j.Category)
                                 .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<List<JobPosting>> GetByCategoryIdAsync(Guid categoryId)
        {
            return await _context.JobPostings
                                 .Where(j => j.CategoryId == categoryId)
                                 .Include(j => j.Category)
                                 .ToListAsync();
        }
        public async Task<List<JobPosting>> GetWhereAsync(Expression<Func<JobPosting, bool>> predicate)
        {
            return await _context.JobPostings
                                 .Where(predicate)
                                 .Include(j => j.Category)
                                 .Include(j => j.JobPostingSkills)
                                     .ThenInclude(jps => jps.Skill)
                                 .ToListAsync();
        }

        public async Task AddAsync(JobPosting entity)
        {
            await _context.JobPostings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobPosting entity)
        {
            _context.JobPostings.Update(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(JobPosting entity)
        {
            _context.JobPostings.Update(entity);
        }

        public void Delete(JobPosting entity)
        {
            _context.JobPostings.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}