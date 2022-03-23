using System.ComponentModel.DataAnnotations;
using riv4lz.core.Models;

namespace riv4lz.casterApi.Dtos;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public CasterProfile? CasterProfile { get; set; }
    public OrganisationProfile? OrganisationProfile { get; set; }
}