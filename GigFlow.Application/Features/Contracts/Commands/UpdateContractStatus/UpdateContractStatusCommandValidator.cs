using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus
{
    public class UpdateContractStatusCommandValidator : AbstractValidator<UpdateContractStatusCommand>
    {
        public UpdateContractStatusCommandValidator()
        {
            RuleFor(x => x.ContractId).NotEmpty();
        }
    }
}
