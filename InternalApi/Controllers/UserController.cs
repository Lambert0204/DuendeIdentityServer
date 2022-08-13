using Microsoft.AspNetCore.Mvc;
using MediatR;
using InternalApi.Domain.Entities;
using InternalApi.Commands;
using ExerciseTwoApi.Queries;

namespace InternalApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var response = await _mediator.Send(new GetUser.Query(id));
        return response == null ? NotFound() : Ok(response.User);
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser(User user)
    {
        var response = await _mediator.Send(new AddUser.Command(user));
        return !response ? BadRequest() : CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
}
