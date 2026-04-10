using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Reviews.Dtos
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}

