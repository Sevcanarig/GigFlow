using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<Guid>
    {
        public Guid FreelancerId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ProjectUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
