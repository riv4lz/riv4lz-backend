using MediatR;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.Mediator.Commands.Profile;

public class UploadImageUrl
{
    public class Command : IRequest<bool>
    {
        public UploadImageUrlDto UploadImageUrlDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;

        public Handler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var profile = await _ctx.Profiles
                .FindAsync(request.UploadImageUrlDto.UserId);

            if (profile is null)
                return false;
            
            var result = await SetImageUrl(profile, request.UploadImageUrlDto);

            return result > 0;
        }

        private async Task<int> SetImageUrl(core.Entities.Profile profile, UploadImageUrlDto uploadImageUrlDto)
        {
            if (uploadImageUrlDto.ImageType == ImgType.Profile)
            {
                profile.ProfileImageUrl = uploadImageUrlDto.ImageUrl;
            }
            else
            {
                profile.BannerImageUrl = uploadImageUrlDto.ImageUrl;
            }
            
            return await _ctx.SaveChangesAsync();
        }
    }
}