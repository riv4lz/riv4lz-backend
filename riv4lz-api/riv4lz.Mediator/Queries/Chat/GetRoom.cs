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
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<ChatRoomWithMessagesDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var chatRoom = await _ctx.ChatRooms
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.Name.Equals(request.RoomName), cancellationToken);
            
            return _mapper.Map<ChatRoomWithMessagesDto>(chatRoom);
        }
    }
}
