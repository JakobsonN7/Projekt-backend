using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<ParticipantModel> Participants { get; set; }
        public DbSet<RegistrationModel> Registrations { get; set; }
        public DbSet<SponsorModel> Sponsors { get; set; }
        public DbSet<VenueModel> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventModel>()
                .HasMany(e => e.Registrations)
                .WithOne(r => r.Event)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<ParticipantModel>()
                .HasMany(p => p.Registrations)
                .WithOne(r => r.Participant)
                .HasForeignKey(r => r.ParticipantId);

            modelBuilder.Entity<SponsorModel>()
                .HasMany(s => s.SponsoredEvents)
                .WithMany(e => e.Sponsors)
                .UsingEntity<Dictionary<string, object>>(
                    "EventSponsor",
                    j => j.HasOne<EventModel>().WithMany().HasForeignKey("EventId"),
                    j => j.HasOne<SponsorModel>().WithMany().HasForeignKey("SponsorId"));

            modelBuilder.Entity<VenueModel>()
                .HasMany(v => v.Events)
                .WithOne(e => e.Venue)
                .HasForeignKey(e => e.VenueId);
        }
    }
}
