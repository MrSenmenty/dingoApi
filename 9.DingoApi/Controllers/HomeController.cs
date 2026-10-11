using Microsoft.AspNetCore.Mvc;

namespace DingoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new { service = "DingoApi", status = "ok" });
    }
}
