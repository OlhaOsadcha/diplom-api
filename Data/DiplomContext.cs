using DiplomApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Data;

public class DiplomContext: DbContext
{
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Livingcost> Livingcosts { get; set; }
    public DbSet<User> Users { get; set; }

    public DiplomContext(DbContextOptions<DiplomContext> options): base(options) {}
}