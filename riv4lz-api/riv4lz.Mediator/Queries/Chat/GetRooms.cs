using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

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
        private readonly IDistributedCache _cache;

        public Handler(IMapper mapper, ChatContext ctx, IDistributedCache cache)
        {
            _mapper = mapper;
            _ctx = ctx;
            _cache = cache;
        }
        public async Task<List<ChatRoomDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var jsonData = await _cache.GetStringAsync("chatrooms");

            if (!jsonData.IsNullOrEmpty())
            {
                var cachedChatRooms = JsonSerializer.Deserialize<List<ChatRoomDto>>(jsonData);
                Console.WriteLine("CACHED ROOMS");
                return cachedChatRooms;
            }
            
            Thread.Sleep(5000);
            var chatRooms = await _ctx.ChatRooms.Select(x => _mapper.Map<ChatRoomDto>(x))
                .ToListAsync(cancellationToken);

            //await _redis.SetCachedChatRooms(chatRooms);
            Console.WriteLine("DB ROOMS");

            return chatRooms;
        }
    }
}