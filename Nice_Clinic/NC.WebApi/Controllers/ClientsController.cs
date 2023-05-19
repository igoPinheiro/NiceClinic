using Microsoft.AspNetCore.Mvc;
using NC.Core.Domain;

namespace NC.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpGet] 
    public IActionResult Get()
    {
        List<Client> clients = new() {
            new Client
            {
                Id=1,
                Name="João do caminhao",
                BirthDate =new DateTime(1988,12,30)
            }
            ,
            new Client
            {
                Id=2,
                Name="Mariao do caminhao",
                BirthDate =new DateTime(1989,11,3)
            },

        };
        return Ok(clients);
    }
}
