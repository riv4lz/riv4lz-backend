using riv4lz.core.Models;

namespace riv4lz.dataAccess.Entities;

public class Offer
{
        public Guid Id { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid CasterId { get; set; } 
        public CasterProfile Caster { get; set; }
}