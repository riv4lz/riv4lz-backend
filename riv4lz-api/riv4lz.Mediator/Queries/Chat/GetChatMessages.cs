using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.Chat;

public class GetChatMessages
{
    
    public class Query : IRequest<List<CommentDto>>
    {
        
    }
    
    public class Handler : IRequestHandler<Query, List<CommentDto>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var messages = await _ctx.Comments
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return messages;
        }
    }
}
