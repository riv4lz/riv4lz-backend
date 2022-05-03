using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.Chat;

public class GetRoom
{ 
    public class Query : IRequest<ChatRoomWithMessagesDto>
    {
        public string RoomName { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, ChatRoomWithMessagesDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<ChatRoomWithMessagesDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var chatRoom = await _ctx.ChatRooms
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.Id.Equals(new Guid(request.RoomName)), cancellationToken);
            
            return _mapper.Map<ChatRoomWithMessagesDto>(chatRoom);
        }
    }
}
