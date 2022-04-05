using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.Requests
{
    public class AddIngredientRequest
    {
        public List<ShelfLife> ShelfLives { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public List<NutritionalProperty> NutritionalValues { get; set; }
    }
}
