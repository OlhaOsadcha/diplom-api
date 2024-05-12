using DiplomApi.Dto;
using DiplomApi.Models;

namespace DiplomApi.Interfaces;

public interface ILivingcostRepository
{
    public Task<IEnumerable<LivingcostDto>> GetAllAsync();
    public Task<Livingcost> GetByIdAsync(Guid id);
    public Task<Guid> AddLivingcostAsync(LivingcostDto livingcost);
    public Task<Guid> UpdateLivingcostAsync(LivingcostDto livingcost);
    public Task<Guid> DeleteLivingcostAsync(Guid id);
    public Task<Guid> UpdateBaselineLivingcostAsync(Guid id);
}