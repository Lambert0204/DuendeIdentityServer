
using InternalApi.Infrastructure.Repository.Interface;
using MediatR;
using Entity = InternalApi.Domain.Entities;

namespace InternalApi.Application.User.Features;

public static class GetUser
{
    public record GetUserQuery(int Id) : IRequest<Response>;

    public record Response(Entity.User User);

    public class Handler : IRequestHandler<GetUserQuery, Response>
    {
        private readonly IRepositoryFactory _repoFactory;
        public Handler(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }
        
        public async Task<Response> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var repository = _repoFactory.AsyncRepository<Entity.User>();
            return new Response(await repository.GetAsync(x => x.Id == request.Id));
        }
    }
}