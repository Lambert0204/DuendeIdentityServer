using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IdentityServerController : ControllerBase
{
    private readonly ILogger<IdentityServerController> _logger;
    public IdentityServerController(ILogger<IdentityServerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public bool Get()
    {
        return true;
    }
}
