using DiplomApi.Data;
using DiplomApi.DTO;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
    public DiplomContext Context {get; set; }
    
    public IncomeController(DiplomContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Income>>> Get()
    {
        IEnumerable<Income> incomes = await Context.Incomes.ToListAsync();

        return Ok(incomes);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Income>>> Post([FromBody]IncomeDTO income)
    {
        Income incomeToAdd = new Income()
        {
            IsBaseline = true,
            Total = 10,
            Salary = income.Salary == "" ? 0 : Convert.ToInt32(income.Salary),
            Pension = income.Pension == "" ? 0 : Convert.ToInt32(income.Pension),
            Deposit = income.Deposit == "" ? 0 : Convert.ToInt32(income.Deposit),
            Other = income.Other == "" ? 0 : Convert.ToInt32(income.Other),
            HasSpouse = income.HasSpouse,
            SalarySpouse = income.SalarySpouse == "" ? 0 : Convert.ToInt32(income.SalarySpouse),
            PensionSpouse = income.PensionSpouse == "" ? 0 : Convert.ToInt32(income.PensionSpouse),
            DepositSpouse = income.DepositSpouse == "" ? 0 : Convert.ToInt32(income.DepositSpouse),
            OtherSpouse = income.OtherSpouse == "" ? 0 : Convert.ToInt32(income.OtherSpouse),
        };
        
        await Context.Incomes.AddAsync(incomeToAdd);
        await Context.SaveChangesAsync();

        IEnumerable<Income> incomes = await Context.Incomes.ToListAsync();

        return Ok(incomes);
    }
    
}