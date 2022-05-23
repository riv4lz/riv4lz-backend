using System.Threading;
using MediatR;
using Moq;
using riv4lz.Mediator.Dtos.Profile;
using riv4lz.Mediator.Queries.Profile;
using Xunit;

namespace riv4lz.mediatr.test;

public class GetProfileTest
{
    private readonly Mock<IMediator> _mediator;

    public GetProfileTest()
    {
        _mediator = new Mock<IMediator>();
    }

    [Fact]
    public void GetProfile_Should_return_profileDto()
    {
        var profile = new ProfileDto { Name = "John Doe" };
        _mediator.Setup(x => x.Send(It.IsAny<GetProfile>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(profile);

        var result = _mediator.Object.Send(new GetProfile()).Result;

        Assert.Equal(profile, result);
    }
    
    [Fact]
    public void GetProfile_Should_Return_Null_IfProfileIsNotFound()
    {
        _mediator.Setup(x => x.Send(It.IsAny<GetProfile>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ProfileDto)null);

        var result = _mediator.Object.Send(new GetProfile()).Result;

        Assert.Null(result);
    }
    
    
    
}