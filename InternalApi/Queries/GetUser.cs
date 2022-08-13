
using InternalApi.Domain.Entities;
using InternalApi.Infrastructure.Repository.Interface;
using MediatR;

namespace ExerciseTwoApi.Queries
{
    public static class GetUser
    {
        public record Query(int Id) : IRequest<Response>;

        public record Response(User User);

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepositoryFactory _repoFactory;
            public Handler(IRepositoryFactory repoFactory)
            {
                _repoFactory = repoFactory;
            }
            
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var repository = _repoFactory.AsyncRepository<User>();
                return new Response(await repository.GetAsync(x => x.Id == request.Id));
            }
        }
    }
}