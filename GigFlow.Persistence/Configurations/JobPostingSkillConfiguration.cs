using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class JobPostingSkillConfiguration : IEntityTypeConfiguration<JobPostingSkill>
    {
        public void Configure(EntityTypeBuilder<JobPostingSkill> builder)
        {
            builder.ToTable("JobPostingSkills");

            builder.HasKey(js => new { js.JobPostingId, js.SkillId });

            builder.HasOne(js => js.JobPosting)
                .WithMany(j => j.JobPostingSkills)
                .HasForeignKey(js => js.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(js => js.Skill)
                .WithMany(s => s.JobPostingSkills)
                .HasForeignKey(js => js.SkillId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}