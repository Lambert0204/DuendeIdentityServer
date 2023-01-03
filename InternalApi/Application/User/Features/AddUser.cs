
using InternalApi.Helpers;
using InternalApi.Infrastructure.Repository.Interface;
using MediatR;
using Entity = InternalApi.Domain.Entities;

namespace InternalApi.Application.User.Features;

public static class AddUser
{
    public class Command : BaseCommand<Result<int>>
    {
        public AddUserDto AddUserDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<int>>
    {
        private readonly IRepositoryFactory _repoFactory;

        public Handler(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }
        
        public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var repository = _repoFactory.AsyncRepository<Entity.User>();

            // TODO: Map
            var user = new Entity.User();
            user.FirstName = request.AddUserDto.FirstName;
            user.LastName = request.AddUserDto.LastName;
            user.Address = request.AddUserDto.Address;
            user.ModifiedBy = request.AddUserDto.ModifiedBy;
            user.CreatedBy = request.AddUserDto.CreatedBy;
            user.Id = 1;

            await repository.AddAsync(user);
            await _repoFactory.SaveChangesAsync();

            return Result<int>.Success(user.Id);
        }
    }
}