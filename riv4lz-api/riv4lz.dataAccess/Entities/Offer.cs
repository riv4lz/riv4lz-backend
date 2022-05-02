using System.ComponentModel.DataAnnotations;
using riv4lz.core.Models;

namespace riv4lz.dataAccess.Entities;

public class Offer
{
        public Guid Id { get; set; }

        public Guid EventId { get; set; }
        [Required]
        public Event Event { get; set; }
        public Guid CasterId { get; set; } 
        [Required]
        public CasterProfile Caster { get; set; }
}