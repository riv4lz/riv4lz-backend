using Microsoft.Extensions.Caching.Distributed;

namespace riv4lz.Mediator;

public interface IDistributedCacheService
{
    Task SetRecordAsync<T>(IDistributedCache cache, 
        string key, 
        T data,
        TimeSpan? absoluteExpireTime = null, 
        TimeSpan? unusedExpireTime = null);

    Task<T> GetRecordAsync<T>(IDistributedCache cache, string key);
}