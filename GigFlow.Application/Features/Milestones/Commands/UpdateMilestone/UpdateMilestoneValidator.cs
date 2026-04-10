using FluentValidation;
using GigFlow.Application.Features.Milestones.Commands.UpdateMilestone;
using System;

namespace GigFlow.Application.Features.Milestones.Validators
{
    public class UpdateMilestoneCommandValidator : AbstractValidator<UpdateMilestoneCommand>
    {
        public UpdateMilestoneCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Milestone Id boş olamaz");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz")
                .MaximumLength(150).WithMessage("Başlık 150 karakterden uzun olamaz");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Açıklama 1000 karakterden uzun olamaz");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalı");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Bitiş tarihi bugünden büyük olmalı");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Geçersiz durum değeri");
        }
    }
}