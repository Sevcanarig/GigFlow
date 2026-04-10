using MediatR;
using Microsoft.AspNetCore.Mvc;
using GigFlow.Application.Features.Milestones.Commands.CreateMilestone;
using GigFlow.Application.Features.Milestones.Commands.UpdateMilestone;
using GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus;
using GigFlow.Application.Features.Milestones.Queries.GetMilestonesByContract;

namespace GigFlow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestonesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MilestonesController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMilestoneCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result); 
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMilestoneCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

       
        [HttpPatch("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateMilestoneStatusCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        
        [HttpGet("contract/{contractId}")]
        public async Task<IActionResult> GetByContract([FromRoute] Guid contractId)
        {
            var query = new GetMilestonesByContractQuery
            {
                ContractId = contractId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}