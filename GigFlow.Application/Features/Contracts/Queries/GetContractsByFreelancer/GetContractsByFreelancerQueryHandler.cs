using AutoMapper;
using GigFlow.Application.Features.Contracts.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer
{
    public class GetContractsByFreelancerQueryHandler
    : IRequestHandler<GetContractsByFreelancerQuery, List<ContractDto>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetContractsByFreelancerQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<List<ContractDto>> Handle(GetContractsByFreelancerQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _contractRepository.GetByFreelancerIdAsync(request.FreelancerId);

            return _mapper.Map<List<ContractDto>>(contracts);
        }
    }
}
