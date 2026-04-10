using GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio;
using GigFlow.Application.Features.Portfolios.Commands.UpdatePortfolio;
using GigFlow.Application.Features.Portfolios.Commands.DeletePortfolio;
using GigFlow.Application.Features.Portfolios.Queries.GetPortfoliosByFreelancer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GigFlow.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfoliosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfoliosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePortfolioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); 
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePortfolioCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePortfolioCommand { Id = id });
            return NoContent();
        }

        
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetByFreelancer(Guid freelancerId)
        {
            var result = await _mediator.Send(
                new GetPortfoliosByFreelancerQuery
                {
                    FreelancerId = freelancerId
                });

            return Ok(result);
        }
    }
}