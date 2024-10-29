using Microsoft.EntityFrameworkCore;
using FitnessClub.FitnessClub.DataAccess.Entities;

namespace FitnessClub.FitnessClub.DataAccess
{
    public class FitnessClubDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TrainingEntity> Trainings { get; set; }

        public FitnessClubDbContext(DbContextOptions<FitnessClubDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связи между User и Role (один-ко-многим)
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Настройка связи многие-ко-многим между User и Training
            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Trainings)
                .WithMany(t => t.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserTraining",
                    j => j.HasOne<TrainingEntity>()
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<UserEntity>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade));
            
           
        }
    }
}