using riv4lz.core.Models;

namespace riv4lz.casterApi.Dtos;

public class CasterDto : UserDto
{
    public string GamerTag { get; set; }
    public CasterProfile Profile { get; set; }
    
}