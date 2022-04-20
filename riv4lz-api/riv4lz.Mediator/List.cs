using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;
using riv4lz.security.DataAccess;

namespace riv4lz.Mediator;

public class List
{
    public class Query : IRequest<List<CasterDtoDemo>>
    {
        
    }
    
    public class Handler : IRequestHandler<Query, List<CasterDtoDemo>>
    {
        private readonly AuthContext _authContext;
        private readonly CasterDbContext _casterDbContext;

        public Handler(AuthContext authContext, CasterDbContext casterDbContext)
        {
            _authContext = authContext;
            _casterDbContext = casterDbContext;
        }

        public Task<List<CasterDtoDemo>> Handle(Query request, CancellationToken cancellationToken)
        {
            // get users
            // get profiles
            // return
            return null;
        }
    }
}