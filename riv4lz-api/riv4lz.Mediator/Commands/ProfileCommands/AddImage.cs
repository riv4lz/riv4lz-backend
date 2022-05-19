using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Cloudinary;

namespace riv4lz.Mediator.Commands.ProfileCommands;

public class AddImage
{
    public class Command: IRequest<bool>
    {
        public IFormFile File { get; set; }
        public Guid UserId { get; set; }
    }
    
    public class Handler: IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(DataContext ctx, IPhotoAccessor photoAccessor)
        {
            _ctx = ctx;
            _photoAccessor = photoAccessor;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var profile = await _ctx.Profiles
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            if (profile is null)
                return false;

            var imageUploadResult = await _photoAccessor.AddPhoto(request.File);

            if (imageUploadResult is null)
                return false;

            var image = new Image()
            {
                Url = imageUploadResult.Url,
                Id = imageUploadResult.PublicId,
                ImageType = ImgType.Profile,
            };
            
            profile.Images = new List<Image>();
            profile.Images.Add(image);

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}