using riv4lz.dataAccess.Cloudinary;
using Xunit;

namespace riv4lz.dataAccess.test.Cloudinary;

public class IPhotoAccessorTest
{
    [Fact]
    public void IPhotoAccessor_IsInterface()
    {
        Assert.True(typeof(IPhotoAccessor).IsInterface);
    }
    
    
}