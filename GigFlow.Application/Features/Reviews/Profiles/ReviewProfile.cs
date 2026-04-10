using AutoMapper;
using GigFlow.Application.Features.Reviews.Dtos;
using GigFlow.Application.Features.Reviews.Commands.CreateReview;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Features.Reviews.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            
            CreateMap<Review, ReviewDto>().ReverseMap();

            
            CreateMap<CreateReviewCommand, Review>();
        }
    }
}