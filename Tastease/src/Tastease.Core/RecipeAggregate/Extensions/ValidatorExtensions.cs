using Ardalis.Result;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.RecipeAggregate.Extensions
{
    public static class ValidatorExtensions
    {
        public static ValidationError ToValidationError(this ValidationFailure error) => new ValidationError 
        {
            Severity = ValidationSeverity.Error,
            ErrorMessage = error.ErrorMessage,
            Identifier = error.PropertyName
        };
    }
}
