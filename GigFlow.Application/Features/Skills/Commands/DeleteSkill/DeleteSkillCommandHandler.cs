using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Skills.Commands.DeleteSkill;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, bool>
{
    private readonly ISkillRepository _skillRepository;

    public DeleteSkillCommandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill == null)
            return false;

        _skillRepository.Delete(skill);
        await _skillRepository.SaveChangesAsync();

        return true;
    }
}