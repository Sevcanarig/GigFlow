using GigFlow.Application.Features.JobPostings.Dtos;

using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById
{
    public record GetJobPostingByIdQuery(Guid Id) : IRequest<JobPostingDto>;
}
