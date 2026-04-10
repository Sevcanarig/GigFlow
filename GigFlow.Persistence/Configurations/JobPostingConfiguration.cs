using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.ToTable("JobPostings");

            
            builder.HasKey(j => j.Id);

           
            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(j => j.Description)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(j => j.BudgetMin)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(j => j.BudgetMax)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(j => j.BudgetType)
                .IsRequired();

            builder.Property(j => j.Duration)
                .IsRequired();

            builder.Property(j => j.ExperienceLevel)
                .IsRequired();

            builder.Property(j => j.Status)
                .HasDefaultValue(Domain.Enums.JobStatus.Open)
                .IsRequired();

            builder.Property(j => j.Deadline)
                .IsRequired(false);

            builder.Property(j => j.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 

            
            builder.HasOne(j => j.Category)
                .WithMany(c => c.JobPostings)
                .HasForeignKey(j => j.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasCheckConstraint(
                "CK_JobPosting_Budget",
                "\"BudgetMax\" >= \"BudgetMin\""
            );

           
            builder.HasIndex(j => j.CategoryId);
        }
    }
}