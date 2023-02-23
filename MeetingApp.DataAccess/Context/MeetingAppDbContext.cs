using MeetingApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataAccess.Context
{
    public class MeetingAppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MeetingAppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MeetingAppDbContext(DbContextOptions<MeetingAppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<EmailRecipient> EmailRecipients { get; set; }
        public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName).HasMaxLength(100);
                entity.Property(x => x.LastName).HasMaxLength(100);
                entity.Property(x => x.Mail).HasMaxLength(200);
                entity.Property(x => x.Phone).HasMaxLength(11);
                entity.Property(x => x.Password);
                entity.Property(x => x.ProfilePhoto);
            });


            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.MeetingName).HasMaxLength(150);
                entity.Property(x => x.StartDate);
                entity.Property(x => x.EndDate);
                entity.Property(x => x.Description).HasMaxLength(500);
                entity.Property(x => x.Document);
                entity.Property(x => x.UserTheCreatedId);

                entity.HasOne(d => d.UserTheCreated)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.UserTheCreatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Subject).HasMaxLength(150);
                entity.Property(x => x.Body);
                entity.Property(x => x.SendDate);
                entity.Property(x => x.SenderUserId);

                entity.HasOne(d => d.SenderUser)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MeetingParticipant>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.MeetingId);
                entity.Property(x => x.UserId);

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingParticipants)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MeetingParticipants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmailRecipient>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.EmailId);
                entity.Property(x => x.UserId);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.EmailRecipients)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmailRecipients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
