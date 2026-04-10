using GigFlow.Application.Features.JobPostings.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory
{
    public record GetJobPostingsByCategoryQuery(Guid CategoryId) : IRequest<List<JobPostingDto>>;
}