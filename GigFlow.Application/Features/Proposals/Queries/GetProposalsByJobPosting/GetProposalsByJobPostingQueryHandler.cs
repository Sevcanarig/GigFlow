using AutoMapper;
using GigFlow.Application.Features.Proposals.Dtos;
using GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting;
using GigFlow.Application.Repositories;
using MediatR;

public class GetProposalsByJobPostingQueryHandler
    : IRequestHandler<GetProposalsByJobPostingQuery, List<ProposalDto>>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IMapper _mapper;

    public GetProposalsByJobPostingQueryHandler(
        IProposalRepository proposalRepository,
        IMapper mapper)
    {
        _proposalRepository = proposalRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposalDto>> Handle(GetProposalsByJobPostingQuery request, CancellationToken cancellationToken)
    {
        var proposals = await _proposalRepository.GetByJobPosting(request.JobPostingId);

        return _mapper.Map<List<ProposalDto>>(proposals);
    }
}