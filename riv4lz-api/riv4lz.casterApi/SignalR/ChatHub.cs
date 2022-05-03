using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using riv4lz.Mediator.Commands.Chat;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries.Chat;

namespace riv4lz.casterApi.SignalR;

public class ChatHub: Hub   
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public ChatHub(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    

    public async Task SendMessage(CreateMessageDto createMessageDto)
    {
        // TODO handle error
        await _mediator.Send( new CreateMessage.Command{CreateMessageDto = createMessageDto});
        
        var roomId = createMessageDto.ChatRoomId.ToString();
        var message = _mapper.Map<MessageDto>(createMessageDto);
        await Clients.Group(roomId).SendAsync("ReceiveMessage", message);
    }

    public async Task SendConnectionId(string connectionId)
    {
        await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
    }

    public async Task JoinRoom(string roomId, string previousRoomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        await LeaveRoom(previousRoomId);
        
        var messages = await _mediator.Send(new GetRoom.Query {RoomId = roomId});

        await Clients.Caller.SendAsync("LoadMessages", messages).ConfigureAwait(true);
    }
    

    private async Task LeaveRoom(string previousRoomId)
    {
        if (!previousRoomId.Equals("none"))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, previousRoomId);
        }
    }

    public override async Task OnConnectedAsync()
    {
        var rooms = await LoadRooms();
        await Clients.Caller.SendAsync("LoadRooms", rooms);
        
        var generalRoom = rooms.FirstOrDefault(x => x.Name == "general");
        var generalRoomId = generalRoom.Id.ToString();
        
        await JoinRoom(generalRoomId, "none");
    }

    private async Task<List<ChatRoomDto>> LoadRooms()
    {
        return await _mediator.Send(new GetRooms.Query());
    }
}
