using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.CoverLetter)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.ProposedAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.EstimatedDuration)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            
            builder.HasOne(x => x.JobPosting)
                .WithMany(x => x.Proposals)
                .HasForeignKey(x => x.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.FreelancerId)
                .IsRequired(false);

            builder.HasIndex(x => new { x.JobPostingId, x.FreelancerId })
                .IsUnique()
                .HasFilter("[FreelancerId] IS NOT NULL");
        }
    }
}