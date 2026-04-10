using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Milestones.Commands.CreateMilestone
{
    public class CreateMilestoneCommandHandler : IRequestHandler<CreateMilestoneCommand, Guid>
    {
        private readonly IMilestoneRepository _milestoneRepository;
        private readonly IContractRepository _contractRepository;

        public CreateMilestoneCommandHandler(IMilestoneRepository milestoneRepository, IContractRepository contractRepository)
        {
            _milestoneRepository = milestoneRepository;
            _contractRepository = contractRepository;
        }

        public async Task<Guid> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetByIdAsync(request.ContractId);
            if (contract == null)
                throw new Exception("Sözleşme bulunamadı.");

            var totalMilestonesAmount = contract.Milestones.Sum(m => m.Amount);
            if (totalMilestonesAmount + request.Amount > contract.TotalAmount)
                throw new Exception("Milestone toplamları sözleşme tutarını aşamaz.");

            var milestone = new Milestone
            {
                Id = Guid.NewGuid(),
                ContractId = request.ContractId,
                Title = request.Title,
                Description = request.Description,
                Amount = request.Amount,
                DueDate = request.DueDate,
                Status = MilestoneStatus.Pending
            };

            await _milestoneRepository.AddAsync(milestone);
            await _milestoneRepository.SaveChangesAsync();

            return milestone.Id;
        }
    }
}