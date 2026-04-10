using GigFlow.Application.Features.Proposals.Commands.CreateProposal;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

public class CreateProposalCommandHandler : IRequestHandler<CreateProposalCommand, Guid>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IJobPostingRepository _jobPostingRepository;

    public CreateProposalCommandHandler(
        IProposalRepository proposalRepository,
        IJobPostingRepository jobPostingRepository)
    {
        _proposalRepository = proposalRepository;
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<Guid> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobPostingRepository.GetByIdAsync(request.JobPostingId);

        if (job == null)
            throw new Exception("JobPosting bulunamadı");

        if (job.Status == JobStatus.Cancelled)
            throw new Exception("Cancelled ilana teklif verilemez");

        if (job.Deadline.HasValue && job.Deadline < DateTime.UtcNow)
            throw new Exception("Deadline geçmiş ilana teklif verilemez");

        
        var freelancerId = request.FreelancerId != Guid.Empty
            ? request.FreelancerId
            : Guid.Parse("11111111-1111-1111-1111-111111111111"); //Henüz bonus kısım tamamlanmadığı için geçici bir freelancerId kullanıyoruz.

        var existing = await _proposalRepository
            .GetByJobPostingAndFreelancer(request.JobPostingId, freelancerId);

        if (existing != null)
            throw new Exception("Aynı freelancer tekrar teklif veremez");

        var proposal = new Proposal
        {
            Id = Guid.NewGuid(),
            JobPostingId = request.JobPostingId,
            FreelancerId = freelancerId,
            CoverLetter = request.CoverLetter,
            ProposedAmount = request.ProposedAmount,
            EstimatedDuration = request.EstimatedDuration,
            Status = ProposalStatus.Pending
        };

        await _proposalRepository.AddAsync(proposal);
        await _proposalRepository.SaveChangesAsync();

        return proposal.Id;
    }
}
