using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus
{
    public class UpdateMilestoneStatusCommandHandler : IRequestHandler<UpdateMilestoneStatusCommand, Unit>
    {
        private readonly IMilestoneRepository _milestoneRepository;

        public UpdateMilestoneStatusCommandHandler(IMilestoneRepository milestoneRepository)
        {
            _milestoneRepository = milestoneRepository;
        }

        public async Task<Unit> Handle(UpdateMilestoneStatusCommand request, CancellationToken cancellationToken)
        {
            var milestone = await _milestoneRepository.GetByIdAsync(request.Id);
            if (milestone == null)
                throw new Exception("Milestone bulunamadı.");

            
            if (request.Status == MilestoneStatus.InProgress && milestone.Status != MilestoneStatus.Pending)
                throw new Exception("Milestone yalnızca Pending durumundan InProgress yapılabilir.");

            if (request.Status == MilestoneStatus.Submitted && milestone.Status != MilestoneStatus.InProgress)
                throw new Exception("Milestone yalnızca InProgress durumundan Submitted yapılabilir.");

            if (request.Status == MilestoneStatus.Approved && milestone.Status != MilestoneStatus.Submitted)
                throw new Exception("Milestone yalnızca Submitted durumunda onaylanabilir.");

            if (request.Status == MilestoneStatus.Rejected && milestone.Status != MilestoneStatus.Submitted)
                throw new Exception("Milestone yalnızca Submitted durumunda reddedilebilir.");

            milestone.Status = request.Status;

            await _milestoneRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}