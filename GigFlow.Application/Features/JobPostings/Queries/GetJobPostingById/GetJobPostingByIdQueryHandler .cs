using AutoMapper;
using GigFlow.Application.Features.JobPostings.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById
{
    public class GetJobPostingByIdQueryHandler : IRequestHandler<GetJobPostingByIdQuery, JobPostingDto>
    {
        private readonly IJobPostingRepository _repository;
        private readonly IMapper _mapper;

        public GetJobPostingByIdQueryHandler(IJobPostingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<JobPostingDto> Handle(GetJobPostingByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<JobPostingDto>(job);
        }
    }
}