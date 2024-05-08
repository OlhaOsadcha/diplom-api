using DiplomApi.Data;
using DiplomApi.Dto;
using DiplomApi.Interfaces;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
    public DiplomContext Context {get; set; }
    private readonly IIncomeRepository _repository;
    
    public IncomeController(DiplomContext context, IIncomeRepository repository)
    {
        Context = context;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Income>>> Get()
    {
        IEnumerable<Income> incomes = await _repository.GetAllAsync();
        return Ok(incomes);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Income>>> Post([FromBody]IncomeDto income)
    {
        Income incomeToAdd = GetIncomeDtoFromIncome(income);
        
        IEnumerable<Income> availableIncomes = await Context.Incomes.ToListAsync();
        incomeToAdd.IsBaseline = !availableIncomes.Any() || incomeToAdd.IsBaseline;
        
        await Context.Incomes.AddAsync(incomeToAdd);
        await Context.SaveChangesAsync();

        IEnumerable<Income> incomes = await _repository.GetAllAsync();
        return Ok(incomes);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Income>>> Put(Guid id, [FromBody] IncomeDto income)
    {
        if (id != income.Id)
        {
            return BadRequest("Employee ID mismatch");
        }
        
        
        IEnumerable<Income> incomes = await _repository.GetAllAsync();
        return Ok(incomes);
    }
    

    private Income GetIncomeDtoFromIncome(IncomeDto income)
    {
        int salary = income.Salary == "" ? 0 : Convert.ToInt32(income.Salary);
        int pension = income.Pension == "" ? 0 : Convert.ToInt32(income.Pension);
        int deposit = income.Deposit == "" ? 0 : Convert.ToInt32(income.Deposit);
        int other = income.Other == "" ? 0 : Convert.ToInt32(income.Other);
        int salarySpouse = income.SalarySpouse == "" ? 0 : Convert.ToInt32(income.SalarySpouse);
        int pensionSpouse = income.PensionSpouse == "" ? 0 : Convert.ToInt32(income.PensionSpouse);
        int depositSpouse = income.DepositSpouse == "" ? 0 : Convert.ToInt32(income.DepositSpouse);
        int otherSpouse = income.OtherSpouse == "" ? 0 : Convert.ToInt32(income.OtherSpouse);

        int total = salary + pension + deposit + other + salarySpouse + pensionSpouse + depositSpouse + otherSpouse;
        
        Income result = new Income()
        {
            IsBaseline = income.IsBaseline,
            Total = total,
            Salary = salary,
            Pension = pension,
            Deposit = deposit,
            Other = other,
            HasSpouse = income.HasSpouse,
            SalarySpouse = salarySpouse,
            PensionSpouse = pensionSpouse,
            DepositSpouse = depositSpouse,
            OtherSpouse = otherSpouse,
        };

        return result;
    }
    
}