using AutoMapper;
using GigFlow.Application.Features.Reviews.Dtos;

using GigFlow.Application.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract
{
    public class GetReviewsByContractQueryHandler : IRequestHandler<GetReviewsByContractQuery, List<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewsByContractQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewsByContractQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetReviewsByContractIdAsync(request.ContractId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}