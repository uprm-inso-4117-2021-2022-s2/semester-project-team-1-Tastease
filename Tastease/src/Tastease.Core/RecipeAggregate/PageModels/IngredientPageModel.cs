using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.PageModels
{
    public class IngredientPageModel
    {
        public IngredientPageModel() 
        {
            ShelfLives = new List<ShelfLifePageModel>();
            NutritionalValues = new List<NutritionalPropertyPageModel>();
        }
        public List<ShelfLifePageModel> ShelfLives { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public List<NutritionalPropertyPageModel> NutritionalValues { get; set; }
        public IngredientId Id { get; internal set; }
    }
}
