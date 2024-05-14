using DiplomApi.Dto;
using DiplomApi.Models;

namespace DiplomApi.Mappers;

public static class IncomeMapper
{
    public static IncomeDto ToIncomeDto(this Income income)
    {
        return new IncomeDto(
            Id: income.Id,
            IsBaseline: income.IsBaseline,
            Year: income.Year,
            Total: income.Total.ToString() == "0" ? String.Empty : income.Total.ToString(),
            Salary: income.Salary.ToString() == "0" ? String.Empty : income.Salary.ToString(),
            Pension: income.Pension.ToString() == "0" ? String.Empty : income.Pension.ToString(),
            Deposit: income.Deposit.ToString() == "0" ? String.Empty : income.Deposit.ToString(),
            Other: income.Other.ToString() == "0" ? String.Empty : income.Other.ToString(),
            HasSpouse: income.HasSpouse,
            SalarySpouse: income.SalarySpouse.ToString() == "0" ? String.Empty : income.SalarySpouse.ToString(),
            PensionSpouse: income.PensionSpouse.ToString() == "0" ? String.Empty : income.PensionSpouse.ToString(),
            DepositSpouse: income.DepositSpouse.ToString() == "0" ? String.Empty : income.DepositSpouse.ToString(),
            OtherSpouse: income.OtherSpouse.ToString() == "0" ? String.Empty : income.OtherSpouse.ToString()
            );
    }
}