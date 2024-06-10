using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class RegistrationModel
    {
        public int RegistrationId { get; set; }

        [Required]
        public int EventId { get; set; }

        public EventModel Event { get; set; }

        [Required]
        public int ParticipantId { get; set; }

        public ParticipantModel Participant { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}