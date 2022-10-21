using Microsoft.AspNetCore.Mvc;

namespace OriginDotNetChallenge.Controllers;

[ApiController]
[Route("pokemon")]
public class PokemonController : ControllerBase
{
    public IActionResult Get()
    {
        return Ok("hello world");
    }
    
}