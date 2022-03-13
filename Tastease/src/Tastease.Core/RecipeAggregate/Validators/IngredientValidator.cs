using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.RecipeAggregate.Validators
{
    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleForEach(x => x.ShelfLives).SetValidator(new ShelfLifeValidator());
            RuleForEach(x => x.NutritionalValues).SetValidator(new NutritionalPropertyValidator());
        }
    }
    public class NutritionalPropertyValidator : AbstractValidator<NutritionalProperty>
    {
        public NutritionalPropertyValidator()
        {
            RuleFor(x => x.Value).Must(x => x > 0);
        }
    }
    public class ShelfLifeValidator : AbstractValidator<ShelfLife>
    {
        public ShelfLifeValidator()
        {
            RuleFor(x => x.Times).NotEmpty().NotNull();
        }
    }
}
