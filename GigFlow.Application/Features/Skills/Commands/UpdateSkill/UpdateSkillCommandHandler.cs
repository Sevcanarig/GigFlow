using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.UpdateSkill;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, bool>
{
    private readonly ISkillRepository _skillRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateSkillCommandHandler(
        ISkillRepository skillRepository,
        ICategoryRepository categoryRepository)
    {
        _skillRepository = skillRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill == null)
            return false;

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category == null)
            throw new Exception("Kategori bulunamadı");

        skill.Name = request.Name;
        skill.CategoryId = request.CategoryId;
        skill.UpdatedDate = DateTime.UtcNow;

        _skillRepository.Update(skill);
        await _skillRepository.SaveChangesAsync();

        return true;
    }
}