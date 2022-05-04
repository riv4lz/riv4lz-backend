using riv4lz.core.Entities;

namespace riv4lz.core.Interfaces;

public interface IMermoryCacheService
{
    List<ChatRoom> GetCachedChatRooms();
}