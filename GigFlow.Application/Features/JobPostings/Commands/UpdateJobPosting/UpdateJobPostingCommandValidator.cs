using FluentValidation;

namespace GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommandValidator : AbstractValidator<UpdateJobPostingCommand>
    {
        public UpdateJobPostingCommandValidator()
        {
            RuleFor(x => x.JobPostingDto.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz")
                .MaximumLength(200);

            RuleFor(x => x.JobPostingDto.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz")
                .MaximumLength(5000);

            RuleFor(x => x.JobPostingDto.BudgetMin)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.JobPostingDto.BudgetMax)
                .GreaterThanOrEqualTo(x => x.JobPostingDto.BudgetMin)
                .WithMessage("Bütçe maksimum, minimumdan küçük olamaz");

            RuleFor(x => x.JobPostingDto.SkillIds)
                .NotEmpty().WithMessage("En az 1 skill seçilmeli")
                .Must(s => s.Count <= 10).WithMessage("En fazla 10 skill seçilebilir");
        }
    }
}