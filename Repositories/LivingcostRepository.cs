using DiplomApi.Data;
using DiplomApi.Dto;
using DiplomApi.Interfaces;
using DiplomApi.Mappers;
using DiplomApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Repositories;

public class LivingcostRepository: ILivingcostRepository
{
    private readonly DiplomContext _context;
    
    public LivingcostRepository(DiplomContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LivingcostDto>> GetAllAsync()
    {
        IEnumerable<Livingcost> livingcosts = await _context.Livingcosts.ToListAsync();
        return livingcosts.Select(c => c.ToLivingcostDto());
    }

    public async Task<Livingcost> GetByIdAsync(Guid id)
    {
        return await _context.Livingcosts.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Guid> AddLivingcostAsync(LivingcostDto livingcost)
    {
        Livingcost livingcostToAdd = GetLivingcostDtoFromLivingcost(livingcost);
        
        IEnumerable<Livingcost> availableLivingcosts = await _context.Livingcosts.ToListAsync();
        livingcostToAdd.IsBaseline = !availableLivingcosts.Any() || livingcostToAdd.IsBaseline;
        
        await _context.Livingcosts.AddAsync(livingcostToAdd);
        await _context.SaveChangesAsync();

        return livingcostToAdd.Id;
    }
    
    public async Task<Guid> UpdateLivingcostAsync(LivingcostDto livingcost)
    {
        Livingcost livingcostChanged = GetLivingcostDtoFromLivingcost(livingcost);

        Livingcost livingcostToUpdate = await GetByIdAsync(livingcost.Id);

        livingcostToUpdate.IsBaseline = livingcostChanged.IsBaseline;
        livingcostToUpdate.Total = livingcostChanged.Total;
        livingcostToUpdate.Mortgage = livingcostChanged.Mortgage;
        livingcostToUpdate.Rent = livingcostChanged.Rent;
        livingcostToUpdate.Loans = livingcostChanged.Loans;
        livingcostToUpdate.Utilities = livingcostChanged.Utilities;
        livingcostToUpdate.Education = livingcostChanged.Education;
        livingcostToUpdate.Markets = livingcostChanged.Markets;
        livingcostToUpdate.Transportation = livingcostChanged.Transportation;
        livingcostToUpdate.Other = livingcostChanged.Other;
        
        await _context.SaveChangesAsync();

        return livingcostToUpdate.Id;
    }

    public async Task<Guid> DeleteLivingcostAsync(Guid id)
    {
        Livingcost livingcostToDelete = await GetByIdAsync(id);
        _context.Livingcosts.Remove(livingcostToDelete);
        await _context.SaveChangesAsync();
        return livingcostToDelete.Id;
    }

    public async Task<Guid> UpdateBaselineLivingcostAsync(Guid id)
    {
        Livingcost livingcostBaseline = await _context.Livingcosts.FirstOrDefaultAsync(i => i.IsBaseline == true);

        if (livingcostBaseline != null)
        {
            livingcostBaseline.IsBaseline = false;
        }
        
        Livingcost livingcostToUpdate = await GetByIdAsync(id);
        livingcostToUpdate.IsBaseline = true;
        await _context.SaveChangesAsync();
        return id;
    }
    
    private Livingcost GetLivingcostDtoFromLivingcost(LivingcostDto livingcost)
    {
        int mortgage = livingcost.Mortgage == "" ? 0 : Convert.ToInt32(livingcost.Mortgage);
        int rent = livingcost.Rent == "" ? 0 : Convert.ToInt32(livingcost.Rent);
        int loans = livingcost.Loans == "" ? 0 : Convert.ToInt32(livingcost.Loans);
        int utilities = livingcost.Utilities == "" ? 0 : Convert.ToInt32(livingcost.Utilities);
        int education = livingcost.Education == "" ? 0 : Convert.ToInt32(livingcost.Education);
        int markets = livingcost.Markets == "" ? 0 : Convert.ToInt32(livingcost.Markets);
        int transportation = livingcost.Transportation == "" ? 0 : Convert.ToInt32(livingcost.Transportation);
        int other = livingcost.Other == "" ? 0 : Convert.ToInt32(livingcost.Other);

        int total = mortgage + rent + loans + utilities + education + markets + transportation + other;
        
        Livingcost result = new Livingcost()
        {
            IsBaseline = livingcost.IsBaseline,
            Total = total,
            Mortgage = mortgage,
            Rent = rent,
            Loans = loans,
            Utilities = utilities,
            Education = education,
            Markets = markets,
            Transportation = transportation,
            Other = other,
        };

        return result;
    }
}