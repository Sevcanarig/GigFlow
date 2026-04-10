using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Proposals.Dtos
{
    public class ProposalDto
    {
        public Guid Id { get; set; }
        public Guid JobPostingId { get; set; }
        public Guid FreelancerId { get; set; } = Guid.Parse("11111111-1111-1111-1111-111111111111"); 
        public string CoverLetter { get; set; }
        public decimal ProposedAmount { get; set; }
        public int EstimatedDuration { get; set; }
        public ProposalStatus Status { get; set; }
    }
}
