using GigFlow.Application.Features.Proposals.Commands.WithdrawProposal;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;

public class WithdrawProposalCommandHandler : IRequestHandler<WithdrawProposalCommand, Unit>
{
    private readonly IProposalRepository _proposalRepository;

    public WithdrawProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<Unit> Handle(WithdrawProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.ProposalId);

        if (proposal == null)
            throw new Exception("Proposal bulunamadı");

        if (proposal.Status == ProposalStatus.Withdrawn)
            throw new Exception("Zaten withdraw edilmiş");

        if (proposal.Status == ProposalStatus.Accepted)
            throw new Exception("Kabul edilmiş teklif geri çekilemez");

        proposal.Status = ProposalStatus.Withdrawn;

        await _proposalRepository.SaveChangesAsync();

        return Unit.Value;
    }
}