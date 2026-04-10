using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Skills.Dtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
