using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Validators;

namespace Tastease.Core.RecipeAggregate.Requests
{
    public class BasePaginationRequest
    {
        public int Page { get; init; } = 0;
        public int Size { get; init; } = 10;
    }
}
