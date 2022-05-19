using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Events;

public class CreateEventDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid OrganisationId { get; set; }
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public TeamDto TeamOne { get; set; }
    [Required]
    public TeamDto TeamTwo { get; set; }
    [Required]
    public double Price { get; set; }
}