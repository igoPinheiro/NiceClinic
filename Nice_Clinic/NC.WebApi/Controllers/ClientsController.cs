using Microsoft.AspNetCore.Mvc;
using NC.Core.Domain;
using NC.Manager.Interfaces;

namespace NC.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientManager clientManager;

    public ClientsController(IClientManager clientManager)
    {
        this.clientManager = clientManager;
    }

    [HttpGet] 
    public async Task<IActionResult> Get()
    {
        return Ok(await clientManager.GetClientsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await clientManager.GetClientAsync(id));
    }
}
