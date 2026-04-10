using GigFlow.Application.Features.Milestones.Dtos;
using MediatR;

public class GetMilestonesByContractQuery : IRequest<List<MilestoneDto>>
{
    public Guid ContractId { get; set; }
}