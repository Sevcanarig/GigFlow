using GigFlow.Application.Features.JobPostings.Dtos;
using MediatR;
using System;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommand : IRequest<Guid>
    {
        public JobPostingCreateDto JobPostingDto { get; set; }

        public CreateJobPostingCommand(JobPostingCreateDto jobPostingDto)
        {
            JobPostingDto = jobPostingDto;
        }
    }
}