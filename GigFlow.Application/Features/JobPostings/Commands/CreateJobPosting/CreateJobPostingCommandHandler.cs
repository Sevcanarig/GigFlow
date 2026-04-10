using AutoMapper;
using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommandHandler
        : IRequestHandler<CreateJobPostingCommand, Guid>
    {
        private readonly IJobPostingRepository _repository;
        private readonly IMapper _mapper;

        public CreateJobPostingCommandHandler(
            IJobPostingRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(
            CreateJobPostingCommand request,
            CancellationToken cancellationToken)
        {
           
            var jobPosting = _mapper.Map<JobPosting>(request.JobPostingDto);

            
            jobPosting.ClientId = request.JobPostingDto.ClientId;

            
            jobPosting.JobPostingSkills = request.JobPostingDto.SkillIds
                .Select(skillId => new JobPostingSkill
                {
                    SkillId = skillId
                })
                .ToList();

            
            await _repository.AddAsync(jobPosting);
            await _repository.SaveChangesAsync();

            return jobPosting.Id;
        }
    }
}