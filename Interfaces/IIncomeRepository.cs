using DiplomApi.Dto;
using DiplomApi.Models;

namespace DiplomApi.Interfaces;

public interface IIncomeRepository
{
    public Task<IEnumerable<IncomeDto>> GetAllAsync();
    public Task<Income> GetByIdAsync(Guid id);
    public Task<Guid> AddIncomeAsync(IncomeDto income);
    public Task<Guid> UpdateIncomeAsync(IncomeDto income);
    public Task<Guid> DeleteIncomeAsync(Guid id);
    public Task<Guid> UpdateBaselineIncomeAsync(Guid id);
}