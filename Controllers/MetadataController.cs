using DiplomApi.Data;
using DiplomApi.Mappers;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<Metadata>> Get()
    {
        Income income = await Context.Incomes.FirstOrDefaultAsync(i => i.IsBaseline == true) ?? new Income();
        Livingcost livingcost = await Context.Livingcosts.FirstOrDefaultAsync(c => c.IsBaseline == true) ?? new Livingcost();
        
        Metadata metadata = new Metadata()
        {
            Income = income.ToIncomeDto(),
            CostOfLiving = livingcost.ToLivingcostDto()
        };

        return Ok(metadata);
    }
}