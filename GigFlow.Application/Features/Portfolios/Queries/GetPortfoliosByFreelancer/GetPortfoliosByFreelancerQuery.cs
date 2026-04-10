using GigFlow.Application.Features.Portfolios.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Portfolios.Queries.GetPortfoliosByFreelancer
{
    public class GetPortfoliosByFreelancerQuery : IRequest<List<PortfolioDto>>
    {
        public Guid FreelancerId { get; set; }
    }
}
