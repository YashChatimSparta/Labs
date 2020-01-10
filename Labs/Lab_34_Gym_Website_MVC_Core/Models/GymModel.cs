namespace Lab_34_Gym_Website_MVC_Core
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GymModel : DbContext
    {

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkoutLog> WorkoutLogs { get; set; }

        public GymModel(DbContextOptions<GymModel> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Exercis>()
                .Property(e => e.ExerciseName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
