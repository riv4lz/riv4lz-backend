using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Chat;
using riv4lz.Mediator.Helpers;

namespace riv4lz.Mediator.Queries.Chat;

public class GetRooms
{
    public class Query : IRequest<List<ChatRoomDto>>
    {
    }
    public class Handler : IRequestHandler<Query, List<ChatRoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly ChatContext _ctx;
        private readonly RedisInstance _redis;

        public Handler(IMapper mapper, ChatContext ctx, RedisInstance redis)
        {
            _mapper = mapper;
            _ctx = ctx;
            _redis = redis;
        }
        public async Task<List<ChatRoomDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var cachedChatRooms = await _redis.Get<List<ChatRoomDto>>("chatrooms");

            if (cachedChatRooms.IsNullOrEmpty())
            {
                var chatRooms = await _ctx.ChatRooms
                    .Select(x => _mapper.Map<ChatRoomDto>(x))
                    .ToListAsync(cancellationToken);
            
                if (chatRooms.IsNullOrEmpty())
                    return null;

                _redis.Set("chatrooms", chatRooms);

                return chatRooms;
            }
            
            Console.WriteLine("CACHED ROOMS");
            return cachedChatRooms;
        }
    }
}