using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommandHandler : IRequestHandler<UpdateJobPostingCommand, Unit>
    {
        private readonly IJobPostingRepository _repository;

        public UpdateJobPostingCommandHandler(IJobPostingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
        {
            
            var entity = await _repository.GetByIdWithSkillsAsync(request.Id);

            if (entity == null)
                throw new Exception("JobPosting bulunamadı");

            
            entity.Title = request.JobPostingDto.Title;
            entity.Description = request.JobPostingDto.Description;
            entity.CategoryId = request.JobPostingDto.CategoryId;
            entity.BudgetMin = request.JobPostingDto.BudgetMin;
            entity.BudgetMax = request.JobPostingDto.BudgetMax;

            
            entity.JobPostingSkills = request.JobPostingDto.SkillIds
                .Select(skillId => new JobPostingSkill
                {
                    SkillId = skillId
                })
                .ToList();

            
            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}