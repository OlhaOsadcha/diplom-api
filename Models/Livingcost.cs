namespace DiplomApi.Models;

public class Livingcost: BaseModel
{
    public bool IsBaseline { get; set; }
    public int Total { get; set; }
    public int Mortgage { get; set; }
    public int Rent { get; set; }
    public int Loans { get; set; }
    public int Utilities { get; set; }
    public int Education { get; set; }
    public int Markets { get; set; }
    public int Transportation { get; set; }
    public int Other { get; set; }
}