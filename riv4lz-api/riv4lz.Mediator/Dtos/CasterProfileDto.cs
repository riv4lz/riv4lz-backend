namespace riv4lz.Mediator.Dtos;

public class CasterProfileDto
{
    public Guid CasterId { get; set; }
    public string? GamerTag { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? TwitchURL { get; set; }
}