namespace DiplomApi.Dto;

public record LivingcostDto(
    Guid Id,
    bool IsBaseline, 
    string Year,
    string Total,
    string Mortgage,
    string Rent,
    string Loans,
    string Utilities,
    string Education,
    string Markets,
    string Transportation,
    string Other
);