using AutoMapper;
using GigFlow.Application.Features.JobPostings.Dtos;
using GigFlow.Domain.Entities;
using System.Linq;

public class JobPostingProfile : Profile
{
    public JobPostingProfile()
    {
        CreateMap<JobPostingCreateDto, JobPosting>();
        CreateMap<JobPostingUpdateDto, JobPosting>();
        CreateMap<JobPosting, JobPostingDto>()
            .ForMember(dest => dest.SkillIds, opt =>
                opt.MapFrom(src => src.JobPostingSkills.Select(js => js.SkillId).ToList()));
    }
}