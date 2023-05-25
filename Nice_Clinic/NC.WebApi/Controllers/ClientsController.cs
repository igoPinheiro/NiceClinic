using Microsoft.AspNetCore.Mvc;
using NC.Core.Domain;
using NC.Core.Shared.ModelViews;
using NC.Manager.Interfaces;
using NC.WebApi.Utils;
using SerilogTimings;

namespace NC.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientManager clientManager;
    private readonly ILogger<ClientsController> logger;

    public ClientsController(IClientManager clientManager, ILogger<ClientsController> logger)
    {
        this.clientManager = clientManager;
        this.logger = logger;
    }

    /// <summary>
    /// Retorna todos os clientes cadastrados na base
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        using(Operation.Time("Tempo de consulta de clientes"))
        {
            return Ok(await clientManager.GetClientsAsync());
        }
    }
    /// <summary>
    /// Retorna um cliente consultado pelo Id
    /// </summary>
    /// <param name="id" example="123">Id do Cliente</param>   
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var c = await clientManager.GetClientAsync(id);
        return c == null ? NotFound(new ApiResponse(404, $"Cliente não encontrado.( id ={id}) ")) : Ok(c);
    }

    /// <summary>
    /// Insere um novo cliente
    /// </summary>
    /// <param name="newClient"></param>
    [HttpPost]
    [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] NewClient newClient)
    {
        try
        {
            var clientAdd = await clientManager.InsertClientAsync(newClient);

            return CreatedAtAction(nameof(Get), new { id = clientAdd.Id }, clientAdd);
        }
        catch (Exception e)
        {
            logger.LogError("Json Novo Cliente Recebido: {@newClient}", newClient);
            logger.LogError("Mensagem: {@msg}",e.Message );
            logger.LogError("Stack: {@msg}", e.StackTrace);
            return BadRequest(e.Message);
        }
       
    }

    /// <summary>
    /// Altera dados de um cliente
    /// </summary>
    /// <param name="updateclient"></param>
    [HttpPut]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromBody] UpdateClient updateclient)
    {
        try
        {
            var clientUpd = await clientManager.UpdateClientAsync(updateclient);

            if (clientUpd == null)
                throw new Exception("Usuario não encontrado");

            return Ok(clientUpd);
        }
        catch (Exception e)
        {
            logger.LogWarning("Json Cliente Recebido: {@updateclient}", updateclient);
            return  BadRequest(e.Message);
        }
        
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
