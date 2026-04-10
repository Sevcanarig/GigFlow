using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(GigFlowDbContext context) : base(context)
        {
        }

        
    }
}
