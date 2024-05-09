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
    public async Task<ActionResult<IEnumerable<Income>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Income>>> Post([FromBody]IncomeDto income)
    {
        await _repository.AddIncomeAsync(income);
        return Ok(await _repository.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Income>>> Put([FromRoute]Guid id, [FromBody] IncomeDto income)
    {
        if (id != income.Id)
        {
            return BadRequest("Employee ID mismatch");
        }
        
        return Ok(await _repository.GetAllAsync());
    }
    
}