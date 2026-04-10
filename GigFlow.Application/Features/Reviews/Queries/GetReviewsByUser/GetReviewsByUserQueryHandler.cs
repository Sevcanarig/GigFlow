using AutoMapper;
using GigFlow.Application.Features.Reviews.Dtos;

using GigFlow.Application.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser
{
    public class GetReviewsByUserQueryHandler : IRequestHandler<GetReviewsByUserQuery, List<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewsByUserQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewsByUserQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetReviewsByUserIdAsync(request.UserId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}