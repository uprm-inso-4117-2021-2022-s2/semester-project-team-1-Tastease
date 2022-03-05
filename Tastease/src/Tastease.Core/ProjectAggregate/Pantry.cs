using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.ProjectAggregate;
public class Pantry : BaseEntity
{
    public Pantry()
    {
      Ingredients = new HashSet<Ingredient>();
      Appliances = new HashSet<Appliance>();
    }
    public Cook Cook { get; set; }
    public string Name { get; set; }
    public ICollection<Appliance> Appliances { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}

