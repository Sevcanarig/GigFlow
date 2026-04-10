using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Milestones.Dtos
{
    public class MilestoneDto
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int Order { get; set; }
        public MilestoneStatus Status { get; set; }
    }
}
