using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.PageModels
{
    public class CookPageModel 
    {
        public CookId Id { get; set; }
        public string Slug => "1";//TODO: make axiluray method in core that does conversion of ID to url friendly id
        public string Name { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<PantryPageModel> Pantries { get; set; } = new List<PantryPageModel>();
        public List<Allergy> Allergies { get; set; } = new List<Allergy>();
    }
}
