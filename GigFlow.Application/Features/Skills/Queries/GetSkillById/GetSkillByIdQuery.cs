using GigFlow.Application.Features.Skills.Dtos;

using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQuery : IRequest<SkillDto>
{
    public Guid Id { get; set; }
}