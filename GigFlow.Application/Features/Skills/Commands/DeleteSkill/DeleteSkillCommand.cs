using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.DeleteSkill;

public class DeleteSkillCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}