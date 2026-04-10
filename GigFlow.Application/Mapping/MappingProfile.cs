using AutoMapper;
using GigFlow.Domain.Entities;
using GigFlow.Application.Features.JobPostings.Dtos;

namespace GigFlow.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobPosting, JobPostingDto>().ReverseMap();
            
        }
    }
}