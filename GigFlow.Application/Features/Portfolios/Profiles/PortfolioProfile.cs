using AutoMapper;
using GigFlow.Application.Features.Portfolios.Commands.CreatePortfolio;
using GigFlow.Application.Features.Portfolios.Commands.UpdatePortfolio;
using GigFlow.Application.Features.Portfolios.Dtos;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Portfolios.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            
            CreateMap<CreatePortfolioCommand, Portfolio>();

            
            CreateMap<UpdatePortfolioCommand, Portfolio>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            
            CreateMap<Portfolio, PortfolioDto>();
        }
    }
}

