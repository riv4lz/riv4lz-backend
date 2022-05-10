using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Dtos.Events;

public class UpcommingEventDto
{
    public EventDto Event { get; set; }
    public ProfileDto Caster { get; set; }
}