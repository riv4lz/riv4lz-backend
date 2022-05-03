using MediatR;
using Microsoft.AspNetCore.SignalR;
using riv4lz.Mediator.Queries.Chat;

namespace riv4lz.casterApi.SignalR;

public class ChatHub: Hub   
{
    private readonly IMediator _mediator;


    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    public async Task SendMessage(string message, string room)
    {
        // TODO store message in db
        await Clients.Group(room).SendAsync("ReceiveMessage", message);
    }

    public async Task SendConnectionId(string connectionId)
    {
        await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
    }

    public async Task JoinRoom(string roomName, string previousRoomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        if (!previousRoomName.Equals("none"))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, previousRoomName);
        }
        var messages = await _mediator.Send(new GetRoom.Query {RoomName = roomName});

        await Clients.Caller.SendAsync("LoadMessages", messages).ConfigureAwait(true);
    }
    

    public async Task LeaveRoom(string previousRoomName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, previousRoomName);
    }

    public override async Task OnConnectedAsync()
    {
        await JoinRoom("general", "none");
    }
    
}
