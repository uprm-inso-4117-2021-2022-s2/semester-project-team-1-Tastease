using Tastease.Core.RecipeAggregate;

namespace Tastease.Web.Models
{
    public class PantryPopupPageModel
    {
        public IEnumerable<Ingredient> SelectedIngredient { get; set; } = new Ingredient[] { };
        public IEnumerable<Appliance> SelectedAppliance { get; set; } = new Appliance[] { };
        public string PantryName { get; set; }
    }
}
