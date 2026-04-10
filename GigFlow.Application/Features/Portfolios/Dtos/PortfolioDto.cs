using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Portfolios.Dtos
{
    public class PortfolioDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ProjectUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
