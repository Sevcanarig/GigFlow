using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;

namespace GigFlow.Application.Features.JobPostings.Dtos
{
    public class JobPostingDto
    {
        public Guid Id { get; set; }              
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public decimal BudgetMin { get; set; }
        public decimal BudgetMax { get; set; }
        public BudgetType BudgetType { get; set; }
        public ProjectDuration Duration { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public DateTime? Deadline { get; set; }
        public Guid ClientId { get; set; }
        public List<Guid> SkillIds { get; set; } = new();
    }
}