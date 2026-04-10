using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }

        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
