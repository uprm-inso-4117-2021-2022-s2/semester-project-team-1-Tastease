
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;
public class InstructionTable
{
    public InstructionTable() 
    {
        MeasuredIngredients = new HashSet<MeasuredIngredientTable>();
    }
    public int Id { get; set; }
    public string Guid { get; set; }
    public string Step { get; init; }
    public int Number { get; init; }
    public List<string> Adjustments { get; set; }
    public ApplianceTable? Appliance { get; set; } 
    public ICollection<MeasuredIngredientTable> MeasuredIngredients { get; set; }
    public RecipeTable Recipe { get; set; }
    public int RecipeId { get; set; }

}

