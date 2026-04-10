using GigFlow.Application.Features.Proposals.Commands.AcceptProposal;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;

public class AcceptProposalCommandHandler : IRequestHandler<AcceptProposalCommand, Unit>
{
    private readonly IProposalRepository _proposalRepository;

    public AcceptProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<Unit> Handle(AcceptProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.ProposalId);

        if (proposal == null)
            throw new Exception("Proposal bulunamadı");

        proposal.Status = ProposalStatus.Accepted;

        var others = await _proposalRepository
            .GetByJobPostingExcludingProposal(proposal.JobPostingId, proposal.Id);

        foreach (var item in others)
        {
            item.Status = ProposalStatus.Rejected;
        }

        await _proposalRepository.SaveChangesAsync();

        return Unit.Value;
    }
}