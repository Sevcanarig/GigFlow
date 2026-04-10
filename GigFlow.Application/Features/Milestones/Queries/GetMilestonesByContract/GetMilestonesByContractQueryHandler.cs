using GigFlow.Application.Features.Milestones.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Milestones.Queries.GetMilestonesByContract
{
    public class GetMilestonesByContractQueryHandler : IRequestHandler<GetMilestonesByContractQuery, List<MilestoneDto>>
    {
        private readonly IMilestoneRepository _milestoneRepository;

        public GetMilestonesByContractQueryHandler(IMilestoneRepository milestoneRepository)
        {
            _milestoneRepository = milestoneRepository;
        }

        public async Task<List<MilestoneDto>> Handle(GetMilestonesByContractQuery request, CancellationToken cancellationToken)
        {
            var milestones = await _milestoneRepository.GetAllAsync();

            return milestones
                .Where(m => m.ContractId == request.ContractId)
                .OrderBy(m => m.Order)
                .Select(m => new MilestoneDto
                {
                    Id = m.Id,
                    ContractId = m.ContractId,
                    Title = m.Title,
                    Description = m.Description,
                    Amount = m.Amount,
                    DueDate = m.DueDate,
                    Order = m.Order,
                    Status = m.Status
                })
                .ToList();
        }
    }
}