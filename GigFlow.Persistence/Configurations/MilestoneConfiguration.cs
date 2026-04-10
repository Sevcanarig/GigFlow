using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            builder.ToTable("Milestones");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(m => m.Description)
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(m => m.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(m => m.Status)
                   .HasDefaultValue(MilestoneStatus.Pending);

            builder.HasOne(m => m.Contract)
                   .WithMany(c => c.Milestones)
                   .HasForeignKey(m => m.ContractId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Order).IsRequired();
        }
    }
}