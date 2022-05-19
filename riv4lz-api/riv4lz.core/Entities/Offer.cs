using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.core.Entities;

public class Offer
{
        public Guid Id { get; set; }
        public OfferStatus OfferStatus { get; set; }

        public Guid EventId { get; set; }
        [Required]
        public Event Event { get; set; }

        public Guid CasterId { get; set; } 
        [Required]
        public Profile Caster { get; set; }
}