using Its.Kaspa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Its.Kaspa.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlockController : ControllerBase
{
    private readonly IBlockService svc;

    public BlockController(IBlockService service)
    {
        svc = service;
    }

    [HttpGet]
    [Route("action/GetBlocks/{lowHash}")]
    public IActionResult GetBalanceByAddress(string lowHash)
    {
        var t = svc.GetBlocks(lowHash);
        return Ok(t.Result);
    }

    [HttpGet]
    [Route("action/GetBlock/{blockHash}")]
    public IActionResult GetBlock(string blockHash)
    {
        var t = svc.GetBlock(blockHash);
        return Ok(t.Result);
    }
}
