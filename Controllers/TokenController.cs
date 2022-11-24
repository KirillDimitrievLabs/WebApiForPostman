using Microsoft.AspNetCore.Mvc;
using WebApiForPostman.Infrastructure;

namespace WebApiForPostman.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase
{
    private readonly TokenService _tokenService;

    public TokenController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpGet(Name = "Token")]
    public string GetToken()
    {
        return _tokenService.GetToken();
    }
}