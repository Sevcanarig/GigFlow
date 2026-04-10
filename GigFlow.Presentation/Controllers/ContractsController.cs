using GigFlow.Application.Features.Contracts.Commands.CreateContract;
using GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus;
using GigFlow.Application.Features.Contracts.Dtos;
using GigFlow.Application.Features.Contracts.Queries.GetContractById;
using GigFlow.Application.Features.Contracts.Queries.GetContractsByClient;
using GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GigFlow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetContractByIdQuery { Id = id };
            var contract = await _mediator.Send(query);
            if (contract == null)
                return NotFound();
            return Ok(contract);
        }

        
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetByFreelancer(Guid freelancerId)
        {
            var query = new GetContractsByFreelancerQuery { FreelancerId = freelancerId };
            var contracts = await _mediator.Send(query);
            return Ok(contracts);
        }

        
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetByClient(Guid clientId)
        {
            var query = new GetContractsByClientQuery { ClientId = clientId };
            var contracts = await _mediator.Send(query);
            return Ok(contracts);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractCommand command)
        {
            var contractId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = contractId }, contractId);
        }

        
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateContractStatusCommand command)
        {
            if (id != command.ContractId)
                return BadRequest("Contract ID mismatch");

            await _mediator.Send(command);
            return NoContent();
        }
    }
}