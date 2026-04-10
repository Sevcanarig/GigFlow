using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigFlow.Persistence.Contexts
{
    public class GigFlowDbContext : DbContext
    {
        public GigFlowDbContext(DbContextOptions<GigFlowDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobPostingSkill> JobPostingSkills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GigFlowDbContext).Assembly);
        }
    }

    public static class SeedData
    {
        public static void Initialize(GigFlowDbContext context)
        {
            if (context.Categories.Any()) return;

            // 1. Kategoriler
            var webDev = new Category { Id = Guid.NewGuid(), Name = "Web Development", CreatedDate = DateTime.UtcNow };
            var mobileDev = new Category { Id = Guid.NewGuid(), Name = "Mobile Development", CreatedDate = DateTime.UtcNow };
            var design = new Category { Id = Guid.NewGuid(), Name = "Design", CreatedDate = DateTime.UtcNow };
            var marketing = new Category { Id = Guid.NewGuid(), Name = "Marketing", CreatedDate = DateTime.UtcNow };
            var dataScience = new Category { Id = Guid.NewGuid(), Name = "Data Science", CreatedDate = DateTime.UtcNow };

            context.Categories.AddRange(webDev, mobileDev, design, marketing, dataScience);

            // 2. Skill'ler
            var skills = new List<Skill>
            {
                new Skill { Id = Guid.NewGuid(), Name = "ASP.NET Core", CategoryId = webDev.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "React", CategoryId = webDev.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Vue.js", CategoryId = webDev.Id, CreatedDate = DateTime.UtcNow },

                new Skill { Id = Guid.NewGuid(), Name = "Flutter", CategoryId = mobileDev.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "React Native", CategoryId = mobileDev.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Swift", CategoryId = mobileDev.Id, CreatedDate = DateTime.UtcNow },

                new Skill { Id = Guid.NewGuid(), Name = "UI/UX Design", CategoryId = design.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Photoshop", CategoryId = design.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Figma", CategoryId = design.Id, CreatedDate = DateTime.UtcNow },

                new Skill { Id = Guid.NewGuid(), Name = "SEO", CategoryId = marketing.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Social Media Marketing", CategoryId = marketing.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Google Ads", CategoryId = marketing.Id, CreatedDate = DateTime.UtcNow },

                new Skill { Id = Guid.NewGuid(), Name = "Python", CategoryId = dataScience.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Machine Learning", CategoryId = dataScience.Id, CreatedDate = DateTime.UtcNow },
                new Skill { Id = Guid.NewGuid(), Name = "Data Analysis", CategoryId = dataScience.Id, CreatedDate = DateTime.UtcNow }
            };

            context.Skills.AddRange(skills);

            // 3. İş İlanları
            var job1 = new JobPosting
            {
                Id = Guid.NewGuid(),
                Title = "E-ticaret Web Sitesi",
                Description = "ASP.NET Core ile e-ticaret sitesi",
                CategoryId = webDev.Id,
                BudgetMin = 1000,
                BudgetMax = 5000,
                BudgetType = BudgetType.Fixed,
                Duration = ProjectDuration.Medium,
                ExperienceLevel = ExperienceLevel.Intermediate,
                Status = JobStatus.Open,
                Deadline = DateTime.UtcNow.AddDays(30),
                CreatedDate = DateTime.UtcNow,
                JobPostingSkills = new List<JobPostingSkill>
                {
                    new JobPostingSkill { SkillId = skills[0].Id }, 
                    new JobPostingSkill { SkillId = skills[1].Id }  
                }
            };

            var job2 = new JobPosting
            {
                Id = Guid.NewGuid(),
                Title = "Mobil Uygulama",
                Description = "Flutter ile cross-platform mobil uygulama",
                CategoryId = mobileDev.Id,
                BudgetMin = 2000,
                BudgetMax = 7000,
                BudgetType = BudgetType.Fixed,
                Duration = ProjectDuration.Medium,
                ExperienceLevel = ExperienceLevel.Intermediate,
                Status = JobStatus.Open,
                Deadline = DateTime.UtcNow.AddDays(40),
                CreatedDate = DateTime.UtcNow,
                JobPostingSkills = new List<JobPostingSkill>
                {
                    new JobPostingSkill { SkillId = skills[3].Id }, 
                    new JobPostingSkill { SkillId = skills[4].Id }  
                }
            };

            var job3 = new JobPosting
            {
                Id = Guid.NewGuid(),
                Title = "SEO & Marketing Campaign",
                Description = "SEO ve dijital pazarlama kampanyası yönetimi",
                CategoryId = marketing.Id,
                BudgetMin = 500,
                BudgetMax = 3000,
                BudgetType = BudgetType.Hourly,
                Duration = ProjectDuration.Short,
                ExperienceLevel = ExperienceLevel.Entry,
                Status = JobStatus.Open,
                Deadline = DateTime.UtcNow.AddDays(20),
                CreatedDate = DateTime.UtcNow,
                JobPostingSkills = new List<JobPostingSkill>
                {
                    new JobPostingSkill { SkillId = skills[9].Id }, 
                    new JobPostingSkill { SkillId = skills[10].Id } 
                }
            };

            context.JobPostings.AddRange(job1, job2, job3);

            context.SaveChanges();
        }
    }
}