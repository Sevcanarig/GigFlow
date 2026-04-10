using GigFlow.Application.Features.Skills.Commands.CreateSkill;
using GigFlow.Application.Features.Skills.Commands.DeleteSkill;
using GigFlow.Application.Features.Skills.Commands.UpdateSkill;
using GigFlow.Application.Features.Skills.Dtos;
using GigFlow.Application.Features.Skills.Queries.GetSkillById;
using GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GigFlow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSkillByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound("Skill bulunamadı");

            var skillDto = new SkillDto
            {
                Id = result.Id,
                Name = result.Name,
                CategoryId = result.CategoryId
            };

            return Ok(new { message = "Skill bulundu", data = skillDto });
        }

     
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var query = new GetSkillsByCategoryQuery { CategoryId = categoryId };
            var skillList = await _mediator.Send(query);

            var skillsDto = skillList.Select(s => new SkillDto
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId
            }).ToList();

            return Ok(new { message = "Kategoriye ait skill listesi", data = skillsDto });
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, $"Skill eklendi: {result}");
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSkillCommand command)
        {
            if (id != command.Id) return BadRequest("Id uyuşmuyor");

            await _mediator.Send(command);
            return Ok("Skill güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSkillCommand { Id = id };
            await _mediator.Send(command);
            return Ok("Skill silindi");
        }
    }
}