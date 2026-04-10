using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<JobPostingSkill> JobPostingSkills { get; set; } = new List<JobPostingSkill>();
    }
}
