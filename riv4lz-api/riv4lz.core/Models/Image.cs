using riv4lz.core.Entities;

namespace riv4lz.core.Models;

public class Image
{
    public string Id { get; set; }
    public string Url { get; set; }
    public ImgType Type { get; set; }
    public bool IsMain { get; set; }

    public ICollection<Profile> CasterProfiles { get; set; }
}