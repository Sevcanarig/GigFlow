using GigFlow.Application.Features.Skills.Dtos;

using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;

public class GetSkillsByCategoryQueryHandler : IRequestHandler<GetSkillsByCategoryQuery, List<SkillDto>>
{
    private readonly ISkillRepository _skillRepository;

    public GetSkillsByCategoryQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<List<SkillDto>> Handle(GetSkillsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var skills = await _skillRepository.GetWhereAsync(x => x.CategoryId == request.CategoryId);

        return skills.Select(x => new SkillDto
        {
            Id = x.Id,
            Name = x.Name,
            CategoryId = x.CategoryId
        }).ToList();
    }
}