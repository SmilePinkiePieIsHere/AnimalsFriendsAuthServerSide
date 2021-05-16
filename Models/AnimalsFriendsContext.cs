using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Models
{
    public class AnimalsFriendsContext : DbContext
    {
        public AnimalsFriendsContext(DbContextOptions<AnimalsFriendsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Animals_Users");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Users");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Animals");
            });

            //modelBuilder.Seed();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }       
    }
}
