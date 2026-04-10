using MediatR;
using System;

namespace GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting
{
    public class DeleteJobPostingCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteJobPostingCommand(Guid id)
        {
            Id = id;
        }
    }
}