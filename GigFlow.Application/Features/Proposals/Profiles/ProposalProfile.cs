using AutoMapper;
using GigFlow.Application.Features.Proposals.Dtos;
using GigFlow.Domain.Entities;

public class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Proposal, ProposalDto>().ReverseMap();
    }
}