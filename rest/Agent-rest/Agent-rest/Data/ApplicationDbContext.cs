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

            modelBuilder.Entity<MissionModel>()
                .HasOne(m => m.Agent)
                .WithMany(a => a.Missions)
                .HasForeignKey(m => m.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MissionModel>()
                .HasOne(m => m.Target)
                .WithMany()
                .HasForeignKey(m => m.TargetId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
