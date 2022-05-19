using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Events;

public class UpdateEventDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public EventStatus EventStatus { get; set; }
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public List<TeamDto> Teams { get; set; }
    [Required]
    public double Price { get; set; }
}