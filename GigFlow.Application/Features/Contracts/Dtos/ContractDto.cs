using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Dtos
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Guid JobPostingId { get; set; }
        public Guid ProposalId { get; set; }
        public Guid FreelancerId { get; set; }
        public Guid ClientId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
