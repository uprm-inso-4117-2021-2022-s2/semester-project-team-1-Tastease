using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;

public class Ingredient : ValueObject
{
    public Ingredient() 
    {
      ShelfLives = new HashSet<ShelfLife>();
      NutritionalValues = new HashSet<NutritionalProperty>();
    }
    public Ingredient(string name, IngredientType type, ICollection<ShelfLife> shelfLives, ICollection<NutritionalProperty> nutritionalValues)
    {
      ShelfLives = shelfLives;
      NutritionalValues = nutritionalValues;
      Name = name;
      Type = type;
    }
    public ICollection<ShelfLife> ShelfLives { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }
    public ICollection<NutritionalProperty> NutritionalValues { get; set; }
}

