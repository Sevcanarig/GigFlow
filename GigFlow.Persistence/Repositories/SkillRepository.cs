using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(GigFlowDbContext context) : base(context)
        {
        }
    }
}