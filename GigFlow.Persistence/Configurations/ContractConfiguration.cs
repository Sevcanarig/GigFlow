using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
           
            builder.ToTable("Contracts");

            
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.FreelancerId)
                .IsRequired();

            builder.Property(x => x.ClientId)
                .IsRequired();

            builder.Property(x => x.JobPostingId)
                .IsRequired();

            builder.Property(x => x.ProposalId)
                .IsRequired();

           
            builder.HasOne(c => c.Proposal)
                .WithOne() 
                .HasForeignKey<Contract>(c => c.ProposalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.ProposalId)
                .IsUnique();

            builder.HasOne(c => c.JobPosting)
                .WithMany(j => j.Contracts) 
                .HasForeignKey(c => c.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Milestones)
                .WithOne(m => m.Contract)
                .HasForeignKey(m => m.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Reviews)
                .WithOne(r => r.Contract)
                .HasForeignKey(r => r.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}