using GigFlow.Application.Features.Proposals.Commands.UpdateProposal;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;

public class UpdateProposalCommandHandler : IRequestHandler<UpdateProposalCommand, Unit>
{
    private readonly IProposalRepository _proposalRepository;

    public UpdateProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<Unit> Handle(UpdateProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (proposal == null)
            throw new Exception("Proposal bulunamadı");

        if (proposal.Status != ProposalStatus.Pending)
            throw new Exception("Sadece Pending teklifler güncellenebilir");

        proposal.CoverLetter = request.CoverLetter;
        proposal.ProposedAmount = request.ProposedAmount;
        proposal.EstimatedDuration = request.EstimatedDuration;

        await _proposalRepository.SaveChangesAsync();

        return Unit.Value;
    }
}