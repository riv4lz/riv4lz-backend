using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.Chat;

public class GetRooms
{
    public class Query : IRequest<List<ChatRoomDto>>
    {
    }
    
    public class Handler : IRequestHandler<Query, List<ChatRoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<ChatRoomDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _ctx.ChatRooms.Select(x => _mapper.Map<ChatRoomDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}