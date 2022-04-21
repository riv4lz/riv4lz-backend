using MediatR;

namespace riv4lz.Mediator.Queries;

public class TemplateQuery
{
    
    public class Query : IRequest<Unit>
    {
        public string Email { get; set; }
    }
    
    public class Handler : IRequestHandler<Query>
    {
        

        public Handler()
        {
           
        }

        public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
        {
            
            return Unit.Value;
        }
    }
}
