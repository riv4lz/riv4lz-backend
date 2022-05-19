using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Chat;

namespace riv4lz.Mediator.Queries.Chat;

public class GetRoom
{ 
    public class Query : IRequest<ChatRoomWithMessagesDto>
    {
        public string RoomId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, ChatRoomWithMessagesDto>
    {
        private readonly IMapper _mapper;
        private readonly ChatContext _ctx;

        public Handler(IMapper mapper, ChatContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<ChatRoomWithMessagesDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var roomId = new Guid(request.RoomId);
            var chatRoom = await _ctx.ChatRooms
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.Id.Equals(roomId), cancellationToken);
            
            return _mapper.Map<ChatRoomWithMessagesDto>(chatRoom);
        }
    }
}
