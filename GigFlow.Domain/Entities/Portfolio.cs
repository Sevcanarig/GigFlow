using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public Guid FreelancerId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string? ProjectUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
