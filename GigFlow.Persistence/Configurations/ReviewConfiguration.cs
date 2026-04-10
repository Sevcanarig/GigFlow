using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.ReviewerId)
                .IsRequired();

            builder.Property(x => x.RevieweeId)
                .IsRequired();

            builder.Property(x => x.ContractId)
                .IsRequired();

            
            builder.HasOne(x => x.Contract)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasIndex(x => new { x.ContractId, x.ReviewerId })
                .IsUnique();
        }
    }
}