using DiplomApi.Dto;
using DiplomApi.Interfaces;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LivingcostController : ControllerBase
{
    private readonly ILivingcostRepository _repository;
    
    public LivingcostController(ILivingcostRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivingcostDto>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<LivingcostDto>>> Post([FromBody]LivingcostDto livingcost)
    {
        await _repository.AddLivingcostAsync(livingcost);
        return Ok(await _repository.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<IEnumerable<LivingcostDto>>> Put([FromRoute]Guid id, [FromBody] LivingcostDto livingcost)
    {
        if (id != livingcost.Id)
        {
            return BadRequest("Employee ID mismatch");
        }

        Livingcost livingcostFound = await _repository.GetByIdAsync(id);

        if (livingcostFound == null)
        {
            return NotFound();
        }

        await _repository.UpdateLivingcostAsync(livingcost);
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpPatch("{id:guid}/baseline")]
    public async Task<ActionResult<IEnumerable<LivingcostDto>>> Patch([FromRoute]Guid id)
    {
        Livingcost livingcostFound = await _repository.GetByIdAsync(id);

        if (livingcostFound == null)
        {
            return NotFound();
        }
        
        await _repository.UpdateBaselineLivingcostAsync(id);
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<LivingcostDto>>> Delete([FromRoute]Guid id)
    {
        Livingcost livingcostFound = await _repository.GetByIdAsync(id);

        if (livingcostFound == null)
        {
            return NotFound();
        }

        await _repository.DeleteLivingcostAsync(id);
        return Ok(await _repository.GetAllAsync());
    }
}