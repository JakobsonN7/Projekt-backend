using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EventModel
    {
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        public string Description { get; set; }

        public int VenueId { get; set; }
        public VenueModel Venue { get; set; }

        public ICollection<RegistrationModel> Registrations { get; set; }
        public ICollection<SponsorModel> Sponsors { get; set; }
    }
}