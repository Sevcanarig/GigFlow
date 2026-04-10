using AutoMapper;
using GigFlow.Application.Features.Contracts.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractsByClient
{
    public class GetContractsByClientQueryHandler
    : IRequestHandler<GetContractsByClientQuery, List<ContractDto>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetContractsByClientQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<List<ContractDto>> Handle(GetContractsByClientQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _contractRepository.GetByClientIdAsync(request.ClientId);

            return _mapper.Map<List<ContractDto>>(contracts);
        }
    }
}
