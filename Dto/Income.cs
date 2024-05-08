namespace DiplomApi.Dto;

public record IncomeDto(
    Guid Id,
    bool IsBaseline, 
    string Total,
    string Salary,
    string Pension,
    string Deposit,
    string Other,
    bool HasSpouse,
    string SalarySpouse,
    string PensionSpouse,
    string DepositSpouse,
    string OtherSpouse
    );
