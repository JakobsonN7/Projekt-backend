using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class VenueModel
    {
        public int VenueId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<EventModel> Events { get; set; }
    }
}
