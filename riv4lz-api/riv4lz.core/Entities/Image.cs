using riv4lz.core.Models;

namespace riv4lz.core.Entities;

public class Image
{
    public string Id { get; set; }
    public string Url { get; set; }
    public ImgType ImageType { get; set; }

    public ICollection<Profile> Profiles { get; set; }
}