using Its.Kaspa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Its.Kaspa.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NetworkController : ControllerBase
{
    private readonly INetworkService svc;

    public NetworkController(INetworkService service)
    {
        svc = service;
    }

    [HttpGet]
    [Route("action/GetCurrentNetwork")]
    public IActionResult GetNetwork()
    {
        var t = svc.GetCurrentNetwork();
        return Ok(t.Result);
    }
}
