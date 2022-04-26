using MediatR;
using Microsoft.AspNetCore.SignalR;
using riv4lz.Mediator.Commands.Chat;
using riv4lz.Mediator.Queries.Chat;

namespace riv4lz.casterApi.SignalR;

public class ChatHub: Hub   
{
    private readonly IMediator _mediator;


    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task SendConnectionId(string connectionId)
    {
        await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
    }


    
   
}
