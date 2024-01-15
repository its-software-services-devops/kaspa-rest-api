using Its.Kaspa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Its.Kaspa.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService svc;

    public AddressController(IAddressService service)
    {
        svc = service;
    }

    [HttpGet]
    [Route("action/GetBalanceByAddress/{address}")]
    public IActionResult GetBalanceByAddress(string address)
    {
        var t = svc.GetBalanceByAddress(address);
        return Ok(t.Result);
    }

    [HttpGet]
    [Route("action/GetUtxosByAddress/{address}")]
    public IActionResult GetUtxosByAddress(string address)
    {
        var t = svc.GetUtxosByAddress(address);
        return Ok(t.Result);
    }

    [HttpGet]
    [Route("action/GetUtxosCountByAddress/{address}")]
    public IActionResult GetUtxosCountByAddress(string address)
    {
        var t = svc.GetUtxosByAddress(address);
        var result = new { UtxosCount = t.Result.Entries.Count };

        return Ok(result);
    }
}
