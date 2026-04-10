using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestone
{
    public class UpdateMilestoneCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public MilestoneStatus Status { get; set; }
    }
}