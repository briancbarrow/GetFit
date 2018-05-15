using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace getfit
{
    public class getFitDbContext : DbContext
    {
        public getFitDbContext(DbContextOptions<getFitDbContext> options) : base(options) { }
        //Reference to the exercise table
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExercise> UserExercises { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exercise>().HasKey(m => m.ExerciseId);
            builder.Entity<User>().HasKey(m => m.UserId);
            builder.Entity<UserExercise>().HasKey(m => m.UserExerciseId);

            base.OnModelCreating(builder);

            // shadow properties???
            builder.Entity<Exercise>().Property<DateTime>("UpdatedTimeStamp");
            builder.Entity<User>().Property<DateTime>("UpdatedTimeStamp");
            builder.Entity<UserExercise>().Property<DateTime>("UpdatedTimeStamp");
            // optionsBuilder.UseNpgsql(Configuration.GetConnectionString("getfitDbContext"));
        }

        public override int SaveChanges() 
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Exercise>();
            updateUpdatedProperty<User>();
            updateUpdatedProperty<UserExercise>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo = 
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            
            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimeStamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}