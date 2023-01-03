using MediatR;

namespace InternalApi.Application.User.Features;

public abstract class BaseQuery<T> : IRequest<T> 
{
    public string LoginToken { get; set; }
    public string LoginUserId { get; set; }
    public string LoginIp { get; set; }
}