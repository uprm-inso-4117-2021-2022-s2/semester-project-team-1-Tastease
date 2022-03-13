using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;
using Tastease.SharedKernel;
using Tastease.SharedKernel.Interfaces;

namespace Tastease.Core.RecipeAggregate;

public class Ingredient : ValueObject
{
    public Ingredient() 
    {
      ShelfLives = new List<ShelfLife>();
      NutritionalValues = new List<NutritionalProperty>();
    }
    public Ingredient(string name, IngredientType type, ICollection<ShelfLife> shelfLives, ICollection<NutritionalProperty> nutritionalValues)
    {
      ShelfLives = shelfLives;
      NutritionalValues = nutritionalValues;
      Name = name;
      Type = type;
    }
    public IEnumerable<ShelfLife> ShelfLives { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }
    public IEnumerable<NutritionalProperty> NutritionalValues { get; set; }
}

