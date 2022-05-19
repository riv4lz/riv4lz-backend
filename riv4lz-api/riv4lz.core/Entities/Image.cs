using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.core.Entities;

public class Image
{
    public string Id { get; set; }
    [Url]
    public string Url { get; set; }
    public ImgType ImageType { get; set; }

    public ICollection<Profile> Profiles { get; set; }
}