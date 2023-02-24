using Microsoft.AspNetCore.Mvc;
using KaniniStock.Domain.Models.SourceModels;
using KaniniStock.Domain.IRepoInterfaces;

namespace KaniniStock.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginContoller : ControllerBase
{
    private readonly ILogin login;

    public LoginContoller(ILogin login)
    {
        this.login = login;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin user)
    {
        var tokenValue = this.login.Login(user);

        if (!tokenValue.Any())
        {
            return BadRequest("Invalid Credentials");
        }
        return Ok(tokenValue);

    }
}

