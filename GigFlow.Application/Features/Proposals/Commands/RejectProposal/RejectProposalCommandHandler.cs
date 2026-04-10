using GigFlow.Application.Features.Proposals.Commands.RejectProposal;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;

public class RejectProposalCommandHandler : IRequestHandler<RejectProposalCommand, Unit>
{
    private readonly IProposalRepository _proposalRepository;

    public RejectProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<Unit> Handle(RejectProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.ProposalId);

        if (proposal == null)
            throw new Exception("Proposal bulunamadı");

        if (proposal.Status != ProposalStatus.Pending)
            throw new Exception("Sadece Pending teklifler reddedilebilir");

        proposal.Status = ProposalStatus.Rejected;

        await _proposalRepository.SaveChangesAsync();

        return Unit.Value;
    }
}