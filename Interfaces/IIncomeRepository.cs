using DiplomApi.Dto;
using DiplomApi.Models;

namespace DiplomApi.Interfaces;

public interface IIncomeRepository
{
    public Task<IEnumerable<Income>> GetAllAsync();
    public Task<Income> GetByIdAsync(Guid id);
    public Task<Guid> AddIncomeAsync(IncomeDto income);
}