using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.RecipeAggregate.Validators
{
    public class AddIngredientRequestValidator : AbstractValidator<AddIngredientRequest>
    {
        public AddIngredientRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleForEach(x => x.ShelfLives).SetValidator(new ShelfLifeValidator());
            RuleForEach(x => x.NutritionalValues).SetValidator(new NutritionalPropertyValidator());
        }
    }
}
