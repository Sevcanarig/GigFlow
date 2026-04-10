using GigFlow.Application.Features.Skills.Dtos;

using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillDto>
{
    private readonly ISkillRepository _skillRepository;

    public GetSkillByIdQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<SkillDto> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill == null)
            return null;

        return new SkillDto
        {
            Id = skill.Id,
            Name = skill.Name,
            CategoryId = skill.CategoryId
        };
    }
}