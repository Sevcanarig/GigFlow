using GigFlow.Application.Features.Proposals.Commands.CreateProposal;
using GigFlow.Application.Features.Proposals.Commands.UpdateProposal;
using GigFlow.Application.Features.Proposals.Commands.WithdrawProposal;
using GigFlow.Application.Features.Proposals.Commands.AcceptProposal;
using GigFlow.Application.Features.Proposals.Commands.RejectProposal;
using GigFlow.Application.Features.Proposals.Queries.GetProposalById;
using GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GigFlow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProposalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("jobposting/{jobPostingId}")]
        public async Task<IActionResult> GetByJobPosting(Guid jobPostingId)
        {
            var query = new GetProposalsByJobPostingQuery { JobPostingId = jobPostingId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProposalByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProposalCommand command)
        {
            var result = await _mediator.Send(command); 
            return CreatedAtAction(nameof(GetById), new { id = result }, result); 
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProposalCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id eşleşmiyor.");

            await _mediator.Send(command);
            return Ok("Güncellendi");
        }

        
        [HttpPatch("withdraw/{id}")]
        public async Task<IActionResult> Withdraw(Guid id)
        {
            var command = new WithdrawProposalCommand { ProposalId = id };
            await _mediator.Send(command);
            return Ok("Silindi (Withdrawn)");
        }

       
        [HttpPatch("accept/{id}")]
        public async Task<IActionResult> Accept(Guid id)
        {
            var command = new AcceptProposalCommand { ProposalId = id };
            await _mediator.Send(command);
            return Ok("Kabul Edildi");
        }

        
        [HttpPatch("reject/{id}")]
        public async Task<IActionResult> Reject(Guid id)
        {
            var command = new RejectProposalCommand { ProposalId = id };
            await _mediator.Send(command);
            return Ok("Reddedildi");
        }
    }
}