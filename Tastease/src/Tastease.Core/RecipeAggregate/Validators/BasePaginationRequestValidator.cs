using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.RecipeAggregate.Validators
{
    public class BasePaginationRequestValidator : AbstractValidator<BasePaginationRequest>
    {
        public BasePaginationRequestValidator() 
        {
            RuleFor(x => x.Size).GreaterThan(0).LessThan(100);
            RuleFor(x => x.Page).GreaterThan(-1);
        }
    }
}
