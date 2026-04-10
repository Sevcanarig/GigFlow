using AutoMapper;
using GigFlow.Application.Features.JobPostings.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory
{
    public class GetJobPostingsByCategoryQueryHandler : IRequestHandler<GetJobPostingsByCategoryQuery, List<JobPostingDto>>
    {
        private readonly IJobPostingRepository _repository;
        private readonly IMapper _mapper;

        public GetJobPostingsByCategoryQueryHandler(IJobPostingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<JobPostingDto>> Handle(GetJobPostingsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByCategoryIdAsync(request.CategoryId);
            return _mapper.Map<List<JobPostingDto>>(list);
        }
    }
}