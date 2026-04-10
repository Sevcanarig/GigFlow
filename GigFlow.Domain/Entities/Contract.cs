using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Contract : BaseEntity
    {
        public Guid JobPostingId { get; set; }
        public Guid ProposalId { get; set; }
        public Guid FreelancerId { get; set; }
        public Guid ClientId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ContractStatus Status { get; set; } = ContractStatus.Active;

        
        public JobPosting JobPosting { get; set; } = null!;
        public Proposal Proposal { get; set; } = null!;

        public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}