using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
