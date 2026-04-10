using FluentValidation;
using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus
{
    public class UpdateMilestoneStatusCommandValidator : AbstractValidator<UpdateMilestoneStatusCommand>
    {
        public UpdateMilestoneStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}