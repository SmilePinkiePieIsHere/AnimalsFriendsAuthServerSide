using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Models
{
    public class AnimalsFriendsContext : DbContext
    {
        //public AnimalsFriendsContext(DbContextOptions<AnimalsFriendsContext> options) : base(options)
        //{
        //    //Scaffold-DbContext "Data Source=DEV\MSDEVSQLSERVER;Initial Catalog=cp.kukui.com;User ID=dev;Password=trash7ar4444;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -ContextDir Data -Context CpContext -Tables Client, Locations, ApplicationErrorLog, LocationsPhones, EmailSendLog, Appointment, SMS_Settings, SMS_Subscription, PhoneNumbersInfo, SMS_Newsletter, Timezones, ExternalAPISettings, RoSystemLeadProfile, ClientSettings, KukuiClientEmailAccounts, ClientEmailCampaignLog, ClientEmailCampaign, ClientEmailCampaignClientNotificationsLog, ClientEmailCampaignUnsubscribed -Force -DataAnnotations
        //}

        public AnimalsFriendsContext(DbContextOptions<AnimalsFriendsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            //modelBuilder.Entity<User>().HasMany(u => u.Posts).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Post>().HasOne(p => p.User);

            //modelBuilder.Entity<EmailSendLog>(entity =>
            //{
            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.EmailSendLog)
            //        .HasForeignKey(d => d.ClientId)
            //        .HasConstraintName("FK_EmailSendLog_Client");
            //});

            //modelBuilder.Entity<Animal>(entity =>
            //{
            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Id)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_Animals_Users_UserId");
            //});

            //modelBuilder.Entity<User>().HasMany(u => u.Animals);
            //modelBuilder.Entity<Animal>().HasOne(p => p.User);          

            modelBuilder.Entity<Animal>().HasMany(u => u.Posts);
            
            modelBuilder.Seed();
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
