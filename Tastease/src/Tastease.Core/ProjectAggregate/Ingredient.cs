using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.ProjectAggregate;

public class Ingredient : BaseEntity
{
    public ICollection<ShelfLife> ShelfLives { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }
    public ICollection<NutritionalProperty> NutritionalValues { get; set; }
}

