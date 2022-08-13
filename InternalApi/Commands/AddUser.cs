using InternalApi.Domain.Entities;
using InternalApi.Infrastructure.Repository.Interface;
using MediatR;

namespace InternalApi.Commands;
public static class AddUser
{
    public record Command(User User) : IRequest<bool>;

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly IRepositoryFactory _repoFactory;
        public Handler(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }
        
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var repository = _repoFactory.AsyncRepository<User>();
            try
            {
                await repository.AddAsync(request.User);
                await _repoFactory.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}