using GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UpdateContractStatusCommandHandler : IRequestHandler<UpdateContractStatusCommand, Unit>
{
    private readonly IContractRepository _contractRepository;

    public UpdateContractStatusCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<Unit> Handle(UpdateContractStatusCommand request, CancellationToken cancellationToken)
    {
        
        var contract = await _contractRepository.GetByIdAsync(request.ContractId);

        if (contract == null)
            throw new Exception("Sözleşme bulunamadı");

        if (contract.Status == ContractStatus.Cancelled)
            throw new Exception("İptal edilmiş sözleşme tekrar aktif edilemez");

        if (contract.Status == ContractStatus.Completed)
            throw new Exception("Tamamlanmış sözleşme güncellenemez");

     
        contract.Status = request.Status;

       
        _contractRepository.Update(contract);
        await _contractRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
