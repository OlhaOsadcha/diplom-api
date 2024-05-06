namespace DiplomApi.Models;

public class Income: BaseModel
{
    public bool IsBaseline { get; set; }
    public int Total { get; set; }
    public int Salary { get; set; }
    public int Pension { get; set; }
    public int Deposit { get; set; }
    public int Other { get; set; }
    public bool HasSpouse { get; set; }
    public int SalarySpouse { get; set; }
    public int PensionSpouse { get; set; }
    public int DepositSpouse { get; set; }
    public int OtherSpouse { get; set; }
}