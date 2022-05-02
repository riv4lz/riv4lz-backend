using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.Chat;

public class GetRooms
{
    public class Query : IRequest<List<ChatRoomDto>>
    {
        public string RoomName { get; set; }
    }
    
    public class Handler : BaseHandler, IRequestHandler<Query, List<ChatRoomDto>>
    {
        public async Task<List<ChatRoomDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}