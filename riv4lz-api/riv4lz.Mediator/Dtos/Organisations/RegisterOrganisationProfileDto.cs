namespace riv4lz.Mediator.Dtos.Organisations;

public class RegisterOrganisationProfileDto
{
    public Guid OrganisationId { get; set; }
    public string OrganisationName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string ProfileImage { get; set; }
    public string BannerImage { get; set; }
    public string FacebookURL { get; set; }
    public string TwitterURL { get; set; }
    public string DiscordURL { get; set; }
    public string TwitchURL { get; set; }
}