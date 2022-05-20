namespace riv4lz.core.Entities;

public class Team
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Event> Events { get; set; }
}