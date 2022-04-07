using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.RecipeAggregate.PageModels
{
    public class PantryPageModel
    {
        public string Name { get; set; }
        public IEnumerable<Appliance> Appliances { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
