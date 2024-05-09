using DiplomApi.Data;
using DiplomApi.Dto;
using DiplomApi.Interfaces;
using DiplomApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly DiplomContext _context;
    
    public IncomeRepository(DiplomContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Income>> GetAllAsync()
    {
        return await _context.Incomes.ToListAsync();
    }

    public async Task<Income> GetByIdAsync(Guid id)
    {
        return await _context.Incomes.FindAsync(id);
    }

    public async Task<Guid> AddIncomeAsync(IncomeDto income)
    {
        Income incomeToAdd = GetIncomeDtoFromIncome(income);
        
        IEnumerable<Income> availableIncomes = await _context.Incomes.ToListAsync();
        incomeToAdd.IsBaseline = !availableIncomes.Any() || incomeToAdd.IsBaseline;
        
        await _context.Incomes.AddAsync(incomeToAdd);
        await _context.SaveChangesAsync();

        return incomeToAdd.Id;
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