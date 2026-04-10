using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Guid>
{
    private readonly ISkillRepository _skillRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateSkillCommandHandler(
        ISkillRepository skillRepository,
        ICategoryRepository categoryRepository)
    {
        _skillRepository = skillRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category == null)
            throw new Exception("Kategori bulunamadı");

        var skill = new Skill
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow
        };

        await _skillRepository.AddAsync(skill);
        await _skillRepository.SaveChangesAsync();

        return skill.Id;
    }
}