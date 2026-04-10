using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Commands.CreateMilestone
{
    public class CreateMilestoneCommand : IRequest<Guid>
    {
        public Guid ContractId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int Order { get; set; }
        public MilestoneStatus Status { get; set; } = MilestoneStatus.Pending;
    }
}