using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.RecipeAggregate.Validators
{
    public class AddApplianceRequestValidator : AbstractValidator<AddApplianceRequest>
    {
        public AddApplianceRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
