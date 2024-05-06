using DiplomApi.Data;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MetadataController : ControllerBase
{
    public DiplomContext Context {get; set; }

    public MetadataController(DiplomContext context)
    {
        Context = context;
    }

    [HttpGet]
    public ActionResult<Metadata> Get()
    {
        Metadata metadata = new Metadata()
        {
            Income = "105000",
            CostOfLiving = "79000"
        };

        return Ok(metadata);
    }
}