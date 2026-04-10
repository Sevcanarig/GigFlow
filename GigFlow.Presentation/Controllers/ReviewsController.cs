using GigFlow.Application.Features.Reviews.Commands.CreateReview;
using GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract;
using GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GigFlow.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByContract),
                new { contractId = result.ContractId },
                result);
        }


        [HttpGet("contract/{contractId}")]
        public async Task<IActionResult> GetByContract(Guid contractId)
        {
            var result = await _mediator.Send(new GetReviewsByContractQuery
            {
                ContractId = contractId
            });

            return Ok(result);
        }

    }
}