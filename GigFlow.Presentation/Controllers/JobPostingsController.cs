using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;
using GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting;
using GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting;
using GigFlow.Application.Features.JobPostings.Dtos;
using GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById;
using GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GigFlow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPostingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetJobPostingByIdQuery(id); 
            var job = await _mediator.Send(query);
            if (job == null) return NotFound("JobPosting bulunamadı");

            return Ok(new { message = "JobPosting bulundu", data = job });
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var query = new GetJobPostingsByCategoryQuery(categoryId); 
            var jobs = await _mediator.Send(query);

            return Ok(new { message = "Kategoriye ait JobPosting listesi", data = jobs });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobPostingCreateDto createDto)
        {
            var command = new CreateJobPostingCommand(createDto); 
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result }, $"JobPosting eklendi: {result}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] JobPostingUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest("Id uyuşmuyor");

           
            var command = new UpdateJobPostingCommand(id, updateDto);
            await _mediator.Send(command);

            return Ok("JobPosting güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteJobPostingCommand(id); 
            await _mediator.Send(command);

            return Ok("JobPosting silindi");
        }
    }
}