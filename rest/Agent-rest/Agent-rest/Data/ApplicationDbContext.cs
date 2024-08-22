using Agent_rest.Model;
using Microsoft.EntityFrameworkCore;

namespace Agent_rest.Data
{
    // קלאס שיורש מדי בי קונטקסט ומקבל ממנו אופציות לשלוח שאילתות לאסקיואל
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {

        public DbSet<AgentModel> Agents{ get; set; }
        public DbSet<TargetModel> Targets{ get; set; }
        public DbSet<MissionModel> Missions{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentModel>()
                .Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.Entity<TargetModel>()
                .Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.Entity<MissionModel>()
                .Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.Entity<MissionModel>()
                .HasOne(mission => mission.Agent)
                .WithMany(agent => agent.OptionalTargets)
                .HasForeignKey(mission => mission.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MissionModel>()
                .HasOne(mission => mission.Target)
                .WithMany()
                .HasForeignKey(m => m.TargetId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
