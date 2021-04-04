using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Models
{
    public class AnimalsFriendsContext : DbContext
    {
        public AnimalsFriendsContext(DbContextOptions<AnimalsFriendsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            //modelBuilder.Entity<User>().HasMany(u => u.Posts).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Post>().HasOne(p => p.User);

            //modelBuilder.Entity<User>().HasMany(u => u.Animals);
            modelBuilder.Entity<Animal>().HasOne(p => p.User);          

            modelBuilder.Entity<Animal>().HasMany(u => u.Posts);

            modelBuilder.Seed();
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
