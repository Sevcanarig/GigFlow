using GigFlow.Application.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting
{
    public class DeleteJobPostingCommandHandler : IRequestHandler<DeleteJobPostingCommand, Unit>
    {
        private readonly IJobPostingRepository _repository;

        public DeleteJobPostingCommandHandler(IJobPostingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteJobPostingCommand request, CancellationToken cancellationToken)
        {
            
            var jobPosting = await _repository.GetByIdAsync(request.Id);

            if (jobPosting == null)
                throw new Exception("JobPosting bulunamadı");

            
            _repository.Delete(jobPosting);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}