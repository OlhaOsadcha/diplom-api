using DiplomApi.Dto;
using DiplomApi.Interfaces;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
    private readonly IIncomeRepository _repository;
    
    public IncomeController(IIncomeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IncomeDto>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<IncomeDto>>> Post([FromBody]IncomeDto income)
    {
        await _repository.AddIncomeAsync(income);
        return Ok(await _repository.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<IEnumerable<IncomeDto>>> Put([FromRoute]Guid id, [FromBody] IncomeDto income)
    {
        if (id != income.Id)
        {
            return BadRequest("Employee ID mismatch");
        }

        Income incomeFound = await _repository.GetByIdAsync(id);

        if (incomeFound == null)
        {
            return NotFound();
        }

        await _repository.UpdateIncomeAsync(income);
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpPatch("{id:guid}/baseline")]
    public async Task<ActionResult<IEnumerable<IncomeDto>>> Patch([FromRoute]Guid id)
    {
        Income incomeFound = await _repository.GetByIdAsync(id);

        if (incomeFound == null)
        {
            return NotFound();
        }
        
        await _repository.UpdateBaselineIncomeAsync(id);
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<IncomeDto>>> Delete([FromRoute]Guid id)
    {
        Income incomeFound = await _repository.GetByIdAsync(id);

        if (incomeFound == null)
        {
            return NotFound();
        }

        await _repository.DeleteIncomeAsync(id);
        return Ok(await _repository.GetAllAsync());
    }
    
}