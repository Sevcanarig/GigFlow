using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestone
{
    public class UpdateMilestoneCommandHandler : IRequestHandler<UpdateMilestoneCommand, Unit>
    {
        private readonly IMilestoneRepository _milestoneRepository;

        public UpdateMilestoneCommandHandler(IMilestoneRepository milestoneRepository)
        {
            _milestoneRepository = milestoneRepository;
        }

        public async Task<Unit> Handle(UpdateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var milestone = await _milestoneRepository.GetByIdAsync(request.Id);
            if (milestone == null)
                throw new Exception("Milestone bulunamadı.");

            var contract = milestone.Contract;
            var otherMilestonesTotal = contract.Milestones
                                               .Where(m => m.Id != milestone.Id)
                                               .Sum(m => m.Amount);

            if (otherMilestonesTotal + request.Amount > contract.TotalAmount)
                throw new Exception("Milestone toplamları sözleşme tutarını aşamaz.");

           
            if (request.Status == MilestoneStatus.InProgress && milestone.Status != MilestoneStatus.Pending)
                throw new Exception("Milestone yalnızca Pending durumundan InProgress yapılabilir.");

            if (request.Status == MilestoneStatus.Submitted && milestone.Status != MilestoneStatus.InProgress)
                throw new Exception("Milestone yalnızca InProgress durumundan Submitted yapılabilir.");

            if ((request.Status == MilestoneStatus.Approved || request.Status == MilestoneStatus.Rejected)
                 && milestone.Status != MilestoneStatus.Submitted)
                throw new Exception("Milestone yalnızca Submitted durumunda onaylanabilir veya reddedilebilir.");

            milestone.Title = request.Title;
            milestone.Description = request.Description ?? milestone.Description;
            milestone.Amount = request.Amount;
            milestone.DueDate = request.DueDate;
            milestone.Status = request.Status;

            await _milestoneRepository.SaveChangesAsync();

            if (contract.Milestones.All(m => m.Status == MilestoneStatus.Approved))
                contract.Status = GigFlow.Domain.Enums.ContractStatus.Completed;

            await _milestoneRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}