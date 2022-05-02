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
    
    public class Handler : IRequestHandler<Query, List<ChatRoomDto>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<ChatRoomDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}