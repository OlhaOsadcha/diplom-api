using System.ComponentModel.DataAnnotations;
using DiplomApi.Dto;

namespace DiplomApi.Models;

public class Metadata
{
    public IncomeDto Income { get; set; }
    public LivingcostDto CostOfLiving { get; set; }
}