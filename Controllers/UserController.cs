using Microsoft.AspNetCore.Mvc;
using WebApiForPostman.Infrastructure;
using WebApiForPostman.Infrastructure.Entities;

namespace WebApiForPostman.Controllers;

// [HttpPut]
// [HttpPatch]
// [HttpDelete]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IInMemoryDbService<User> _inMemoryDbService;

    public UserController(IInMemoryDbService<User> inMemoryDbService)
    {
        _inMemoryDbService = inMemoryDbService;
    }

    [HttpGet(Name = "User")]
    public IEnumerable<User> Get()
    {
        return _inMemoryDbService.GetUsers();
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDto user)
    {
        if (user.Name == null) return BadRequest("Name is null or empty");
        if (user.Login == null) return BadRequest("Login is null or empty");
        if (user.PhoneNumber == null) return BadRequest("PhoneNumber is null or empty");

        var userToReturn = _inMemoryDbService.CreateUser(user.Name, user.Login, user.Age, user.PhoneNumber);
        return Ok(userToReturn);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            _inMemoryDbService.DeleteUser(userId);
            return Ok(userId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
    {
        try
        {
            var userToReturn = _inMemoryDbService.UpdateUser(id, userDto.Name ?? null, userDto.Login ?? null,
                userDto.Age == 0 ? -1 : userDto.Age, userDto.PhoneNumber ?? null);
            return Ok(userToReturn);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    public IActionResult UpdateUser(int id, string? name, string? login, int? age, string? phoneNumber)
    {
        try
        {
            var userToReturn = _inMemoryDbService.UpdateUser(id, name, login, age, phoneNumber);
            return Ok(userToReturn);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}