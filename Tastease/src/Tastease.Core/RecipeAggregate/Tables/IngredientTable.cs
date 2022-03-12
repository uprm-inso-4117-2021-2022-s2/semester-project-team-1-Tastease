using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class IngredientTable
{
    public IngredientTable() 
    {
      ShelfLives = new HashSet<ShelfLifeTable>();
      NutritionalValues = new HashSet<NutritionalPropertyTable>();
    }
    public int Id { get; set; }
    public string Guid { get; set; }
    public ICollection<ShelfLifeTable> ShelfLives { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }
    public ICollection<NutritionalPropertyTable> NutritionalValues { get; set; }
}

