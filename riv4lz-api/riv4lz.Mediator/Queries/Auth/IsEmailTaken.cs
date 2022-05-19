using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.security.DataAccess;

namespace riv4lz.Mediator.Queries.Auth;

public class IsEmailTaken
{
    public class Query : IRequest<bool>
    {
        public string Email { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, bool>
    {
        private readonly AuthContext _authContext;
        

        public Handler(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _authContext.Users
                .FirstOrDefaultAsync(u => request.Email
                    .Equals(u.Email), cancellationToken);

            return user is not null;
        }
    }
}