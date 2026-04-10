using GigFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Milestone : BaseEntity
    {
        public Guid ContractId { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public decimal Amount { get; set; }
        public int Order { get; set; }

        public DateTime DueDate { get; set; }

        public MilestoneStatus Status { get; set; } = MilestoneStatus.Pending;

        public Contract Contract { get; set; } = null!;
    }
}
