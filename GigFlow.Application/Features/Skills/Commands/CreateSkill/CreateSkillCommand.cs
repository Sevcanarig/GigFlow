using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.CreateSkill;

public class CreateSkillCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}