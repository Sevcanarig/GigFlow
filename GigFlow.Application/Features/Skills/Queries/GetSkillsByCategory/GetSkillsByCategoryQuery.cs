using GigFlow.Application.Features.Skills.Dtos;

using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;

public class GetSkillsByCategoryQuery : IRequest<List<SkillDto>>
{
    public Guid CategoryId { get; set; }
}