using riv4lz.Mediator.Dtos.Chat;

namespace riv4lz.casterApi.Interfaces;

public interface IChatHub
{
    Task SendMessage(CreateMessageDto createMessageDto);
    Task SendConnectionId(string connectionId);
    Task JoinRoom(string roomId, string previousRoomId);
    Task LeaveRoom(string previousRoomId);
    Task OnConnectedAsync();
    Task<List<ChatRoomDto>> LoadRooms();
}