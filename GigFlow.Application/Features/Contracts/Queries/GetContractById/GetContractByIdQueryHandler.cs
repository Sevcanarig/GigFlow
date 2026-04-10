using AutoMapper;
using GigFlow.Application.Features.Contracts.Dtos;
using GigFlow.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Queries.GetContractById
{
    public class GetContractByIdQueryHandler
    : IRequestHandler<GetContractByIdQuery, ContractDto>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetContractByIdQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<ContractDto> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetByIdAsync(request.Id);

            if (contract == null)
                throw new Exception("Contract not found");

            return _mapper.Map<ContractDto>(contract);
        }
    }
}
