using Microsoft.AspNetCore.Mvc;
using NC.Core.Domain;
using NC.Core.Shared.ModelViews;
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NewClient newClient)
    {
        var clientAdd = await clientManager.InsertClientAsync(newClient);

        return CreatedAtAction(nameof(Get), new { id = clientAdd.Id }, clientAdd);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateClient updateclient)
    {
        var clientUpd = await clientManager.UpdateClientAsync(updateclient);

        if (clientUpd == null)
            return NotFound();

        return Ok(clientUpd);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await clientManager.DeleteClientAsync(id);

        return NoContent();
    }
}
