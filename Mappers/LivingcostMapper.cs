using DiplomApi.Dto;
using DiplomApi.Models;

namespace DiplomApi.Mappers;

public static class LivingcostMapper
{
    public static LivingcostDto ToLivingcostDto(this Livingcost livingcost)
    {
        return new LivingcostDto(
            Id: livingcost.Id,
            IsBaseline: livingcost.IsBaseline,
            Year: livingcost.Year,
            Total: livingcost.Total.ToString() == "0" ? String.Empty : livingcost.Total.ToString(),
            Mortgage: livingcost.Mortgage.ToString() == "0" ? String.Empty : livingcost.Mortgage.ToString(),
            Rent: livingcost.Rent.ToString() == "0" ? String.Empty : livingcost.Rent.ToString(),
            Loans: livingcost.Loans.ToString() == "0" ? String.Empty : livingcost.Loans.ToString(),
            Utilities: livingcost.Utilities.ToString() == "0" ? String.Empty : livingcost.Utilities.ToString(),
            Education: livingcost.Education.ToString() == "0" ? String.Empty : livingcost.Education.ToString(),
            Markets: livingcost.Markets.ToString() == "0" ? String.Empty : livingcost.Markets.ToString(),
            Transportation: livingcost.Transportation.ToString() == "0" ? String.Empty : livingcost.Transportation.ToString(),
            Other: livingcost.Other.ToString() == "0" ? String.Empty : livingcost.Other.ToString()
            );
    }
}