using DiplomApi.Data;
using DiplomApi.Interfaces;
using DiplomApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly DiplomContext _context;
    
    public IncomeRepository(DiplomContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Income>> GetAllAsync()
    {
        return await _context.Incomes.ToListAsync();
    }
/*
    public Task<Income> GetByIdAsync()
    {
        return NotImplementedException();
    }
*/
}