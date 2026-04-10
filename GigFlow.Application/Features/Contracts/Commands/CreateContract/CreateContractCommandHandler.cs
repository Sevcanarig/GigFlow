using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Contracts.Commands.CreateContract
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Guid>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IProposalRepository _proposalRepository;
        private readonly IJobPostingRepository _jobPostingRepository;

        public CreateContractCommandHandler(
            IContractRepository contractRepository,
            IProposalRepository proposalRepository,
            IJobPostingRepository jobPostingRepository)
        {
            _contractRepository = contractRepository;
            _proposalRepository = proposalRepository;
            _jobPostingRepository = jobPostingRepository;
        }

        public async Task<Guid> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            
            var proposal = await _proposalRepository.GetByIdAsync(request.ProposalId);
            if (proposal == null)
                throw new Exception("Teklif bulunamadı");

            if (proposal.Status != ProposalStatus.Accepted)
                throw new Exception("Sadece kabul edilmiş teklifler için sözleşme oluşturulabilir");

            
            var existingContract = await _contractRepository.GetByProposalIdAsync(proposal.Id);
            if (existingContract != null)
                throw new Exception("Bu teklif için zaten bir sözleşme oluşturulmuş");

            
            var jobPosting = await _jobPostingRepository.GetByIdAsync(proposal.JobPostingId);
            if (jobPosting == null)
                throw new Exception("İş ilanı bulunamadı");

            
            var contract = new Contract
            {
                Id = Guid.NewGuid(),
                ProposalId = proposal.Id,
                JobPostingId = proposal.JobPostingId,
                FreelancerId = proposal.FreelancerId ?? throw new Exception("FreelancerId boş olamaz"),
                ClientId = jobPosting.ClientId ?? throw new Exception("ClientId boş olamaz"),
                TotalAmount = proposal.ProposedAmount,
                StartDate = DateTime.UtcNow,
                Status = ContractStatus.Active
            };

            await _contractRepository.AddAsync(contract);

            
            jobPosting.Status = JobStatus.InProgress;
            _jobPostingRepository.Update(jobPosting);

            
            await _contractRepository.SaveChangesAsync();

            return contract.Id;
        }
    }
}