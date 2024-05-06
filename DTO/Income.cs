namespace DiplomApi.DTO;

public record IncomeDTO(
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
