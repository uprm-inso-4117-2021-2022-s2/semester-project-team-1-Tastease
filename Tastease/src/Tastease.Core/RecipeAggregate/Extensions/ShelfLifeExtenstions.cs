using Tastease.Core.Literals;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Extenstions;
public static class ShelfLifeExtenstions 
{
    public static ShelfLife ToShelfLife(this ShelfLifeTable shelfLife) => new ShelfLife
    {
        State = shelfLife.State,
        Times = shelfLife.Values
            .Where(value => value.Type == ShelfLifeValueType.Time 
                && value.Nameof == nameof(TimeOnly))
            .Select(value => TimeOnly.Parse(value.Value))
    };
}
