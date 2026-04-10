using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.ProjectUrl)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.FreelancerId)
                .IsRequired();

            
        }
    }
}