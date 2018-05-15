using Microsoft.EntityFrameworkCore;

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
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql(Configuration.GetConnectionString("getfitDbContext"));
        // }
    }
}