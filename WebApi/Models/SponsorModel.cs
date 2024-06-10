using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SponsorModel
    {
        public int SponsorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal ContributionAmount { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public ICollection<EventModel> SponsoredEvents { get; set; }
    }
}
