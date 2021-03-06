using System.Text.Json;
using StackExchange.Redis;

namespace riv4lz.Mediator.Helpers;

public class RedisInstance
{
    private readonly IDatabase _cache;
    public RedisInstance(IConnectionMultiplexer redis)
    {
        _cache = redis.GetDatabase();
    }
    
    public async void Set<T>(string key, T value)
    {
        var jsonData = JsonSerializer.Serialize(value);
        try
        {
            await _cache.StringSetAsync(key, jsonData, TimeSpan.FromMinutes(1));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<T> Get<T>(string key)
    {
        try
        {
            var data = await _cache.StringGetAsync(key);
        
            if (data.IsNullOrEmpty)
                return default;
        
            return JsonSerializer.Deserialize<T>(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}