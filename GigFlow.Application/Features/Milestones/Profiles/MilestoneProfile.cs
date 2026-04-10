using AutoMapper;
using GigFlow.Domain.Entities;
using GigFlow.Application.Features.Milestones.Dtos;

public class MilestoneProfile : Profile
{
    public MilestoneProfile()
    {
        CreateMap<Milestone, MilestoneDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}