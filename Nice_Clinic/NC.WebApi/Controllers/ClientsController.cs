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

    /// <summary>
    /// Retorna todos os clientes cadastrados na base
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        return Ok(await clientManager.GetClientsAsync());
    }
    /// <summary>
    /// Retorna um cliente consultado pelo Id
    /// </summary>
    /// <param name="id" example="123">Id do Cliente</param>   
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await clientManager.GetClientAsync(id));
    }

    /// <summary>
    /// Insere um novo cliente
    /// </summary>
    /// <param name="newClient"></param>
    [HttpPost]
    [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] NewClient newClient)
    {
        var clientAdd = await clientManager.InsertClientAsync(newClient);

        return CreatedAtAction(nameof(Get), new { id = clientAdd.Id }, clientAdd);
    }

    /// <summary>
    /// Altera dados de um cliente
    /// </summary>
    /// <param name="updateclient"></param>
    [HttpPut]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromBody] UpdateClient updateclient)
    {
        var clientUpd = await clientManager.UpdateClientAsync(updateclient);

        if (clientUpd == null)
            return NotFound();

        return Ok(clientUpd);
    }

    /// <summary>
    /// Exclui um cliente
    /// </summary>
    /// <param name="id" example="123">Id do cliente</param>
    /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base de dados</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await clientManager.DeleteClientAsync(id);

        return NoContent();
    }
}
