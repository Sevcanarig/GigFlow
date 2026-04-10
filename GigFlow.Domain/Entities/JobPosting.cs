using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class JobPosting : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        
        public decimal BudgetMin { get; set; }
        public decimal BudgetMax { get; set; }
        public BudgetType BudgetType { get; set; }

        
        public ProjectDuration Duration { get; set; }  
        public ExperienceLevel ExperienceLevel { get; set; }
        public JobStatus Status { get; set; } = JobStatus.Open;

        
        public Guid? ClientId { get; set; }

        
        public DateTime? Deadline { get; set; }

        
        public ICollection<JobPostingSkill> JobPostingSkills { get; set; } = new List<JobPostingSkill>();
        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
