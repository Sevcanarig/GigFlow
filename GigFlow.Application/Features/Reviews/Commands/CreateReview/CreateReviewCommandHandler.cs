using AutoMapper;
using GigFlow.Application.Features.Reviews.Dtos;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);

            review.Id = Guid.NewGuid(); 

            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();

            return _mapper.Map<ReviewDto>(review); 
        }
    }
}