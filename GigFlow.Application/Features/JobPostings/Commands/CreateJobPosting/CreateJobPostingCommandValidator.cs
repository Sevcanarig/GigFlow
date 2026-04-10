using FluentValidation;
using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommandValidator : AbstractValidator<CreateJobPostingCommand>
    {
        public CreateJobPostingCommandValidator()
        {
            RuleFor(x => x.JobPostingDto.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz")
                .MaximumLength(200).WithMessage("Başlık maksimum 200 karakter olmalı");

            RuleFor(x => x.JobPostingDto.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz")
                .MaximumLength(5000).WithMessage("Açıklama maksimum 5000 karakter olmalı");

            RuleFor(x => x.JobPostingDto.BudgetMin)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum bütçe 0'dan küçük olamaz");

            RuleFor(x => x.JobPostingDto.BudgetMax)
                .GreaterThanOrEqualTo(x => x.JobPostingDto.BudgetMin)
                .WithMessage("Maksimum bütçe minimumdan küçük olamaz");

            RuleFor(x => x.JobPostingDto.SkillIds)
                .NotEmpty().WithMessage("En az 1 skill seçilmeli")
                .Must(s => s.Count <= 10).WithMessage("En fazla 10 skill seçilebilir");
        }
    }
}