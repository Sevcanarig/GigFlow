using GigFlow.Application.Features.JobPostings.Dtos;
using MediatR;
using System;

namespace GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public JobPostingUpdateDto JobPostingDto { get; set; }

        public UpdateJobPostingCommand(Guid id, JobPostingUpdateDto jobPostingDto)
        {
            Id = id;
            JobPostingDto = jobPostingDto;
        }
    }
}