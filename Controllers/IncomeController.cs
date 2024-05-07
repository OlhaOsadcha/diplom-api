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
        Income incomeToAdd = GetIncomeDtoFromIncome(income);
        
        IEnumerable<Income> availableIncomes = await Context.Incomes.ToListAsync();
        incomeToAdd.IsBaseline = !availableIncomes.Any() || incomeToAdd.IsBaseline;
        
        await Context.Incomes.AddAsync(incomeToAdd);
        await Context.SaveChangesAsync();

        IEnumerable<Income> incomes = await Context.Incomes.ToListAsync();

        return Ok(incomes);
    }

    private Income GetIncomeDtoFromIncome(IncomeDTO income)
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