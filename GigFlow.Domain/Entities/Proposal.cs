using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Proposal : BaseEntity
    {
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }

        public Guid? FreelancerId { get; set; }

        public string CoverLetter { get; set; }

        public decimal ProposedAmount { get; set; }
        public int EstimatedDuration { get; set; }

        public ProposalStatus Status { get; set; } = ProposalStatus.Pending;
    }
}
