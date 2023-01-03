using Microsoft.AspNetCore.Mvc;
using MediatR;
using InternalApi.Domain.Entities;
using InternalApi.Application.User.Features;

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
        var response = await _mediator.Send(new GetUser.GetUserQuery(id));
        return response == null ? NotFound() : Ok(response.User);
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser(AddUserDto addUserDto)
    {
        var response = await _mediator.Send(new AddUser.Command(){ AddUserDto = addUserDto });
        return CreatedAtAction(nameof(GetUser), new { id = response });
    }
}
