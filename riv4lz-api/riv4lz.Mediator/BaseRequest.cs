using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using riv4lz.dataAccess;

namespace riv4lz.Mediator;

public class BaseRequest
{
    protected IMapper _mapper;
    protected DataContext _ctx;
    
}