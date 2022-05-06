using System.Text.Json;
using riv4lz.Mediator.Dtos;
using StackExchange.Redis;

namespace riv4lz.Mediator;

public class RedisService
{
    private readonly IDatabase _db;

    public RedisService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task<List<ChatRoomDto>> GetCachedChatRooms()
    {
        var data = await _db.StringGetAsync("chatrooms");

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<List<ChatRoomDto>>(data);
    }

    public async Task SetCachedChatRooms(List<ChatRoomDto> chatRooms)
    {
        await _db.StringSetAsync("chatrooms", JsonSerializer.Serialize(chatRooms), TimeSpan.FromDays(30));
    }
}