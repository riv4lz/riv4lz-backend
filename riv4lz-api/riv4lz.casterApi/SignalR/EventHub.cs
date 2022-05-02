using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace riv4lz.casterApi.SignalR;

public class EventHub: Hub
{
    private readonly IMediator _mediator;

    public EventHub(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // public async Task CreateEven
}