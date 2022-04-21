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
    
    public async Task SendMessage(CreateMessage.Command command)
    {
        var message = await _mediator.Send(command);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();

        var result = await _mediator.Send(new GetChatMessages.Query());
        await Clients.Caller.SendAsync("ReceiveMessages", result);
    }
}
