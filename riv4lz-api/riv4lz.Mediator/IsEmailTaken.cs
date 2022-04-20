using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;
using riv4lz.security.DataAccess;

namespace riv4lz.Mediator;

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
            var user = _authContext.Users.FirstOrDefault(u => request.Email.Equals(u.Email));

            return user != null;
        }
    }
}