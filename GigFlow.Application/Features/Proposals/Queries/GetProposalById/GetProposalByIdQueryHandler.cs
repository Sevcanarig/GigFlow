using AutoMapper;
using GigFlow.Application.Features.Proposals.Dtos;
using GigFlow.Application.Features.Proposals.Queries.GetProposalById;
using GigFlow.Application.Repositories;
using MediatR;

public class GetProposalByIdQueryHandler
    : IRequestHandler<GetProposalByIdQuery, ProposalDto>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IMapper _mapper;

    public GetProposalByIdQueryHandler(
        IProposalRepository proposalRepository,
        IMapper mapper)
    {
        _proposalRepository = proposalRepository;
        _mapper = mapper;
    }

    public async Task<ProposalDto> Handle(GetProposalByIdQuery request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (proposal == null)
            throw new Exception("Proposal bulunamadı");

        return _mapper.Map<ProposalDto>(proposal);
    }
}