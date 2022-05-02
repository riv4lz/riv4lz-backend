using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using riv4lz.dataAccess;

namespace riv4lz.Mediator;

public class BaseHandler
{
    public IMapper _mapper;
    public DataContext _ctx;

    public BaseHandler(IMapper mapper, DataContext ctx)
    {
        _mapper = mapper;
        _ctx = ctx;
    }

    public BaseHandler()
    {
    }
}