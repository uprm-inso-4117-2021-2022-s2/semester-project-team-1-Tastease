using Tastease.Core.Literals;
using Tastease.Core.RecipeAggregate.PageModels;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Extenstions;
public static class ShelfLifeExtenstions 
{
    public static ShelfLife ToShelfLife(this ShelfLifeTable shelfLife) => new ShelfLife
    {
        State = shelfLife.State,
        Time = TimeSpan.Parse(shelfLife.Time)
    }; 
    public static ShelfLifeTable ToShelfLifeTable(this ShelfLife shelfLife) => new ShelfLifeTable
    {
        State = shelfLife.State,
        Time = shelfLife.Time.ToString()
    };
    public static ShelfLifePageModel ToShelfLifePageModel(this ShelfLife shelfLife) => new ShelfLifePageModel
    {
        State = shelfLife.State,
        TimeAsString = shelfLife.Time.ToString(),
    };
    public static ShelfLife ToShelfLife(this ShelfLifePageModel shelfLife) => new ShelfLife
    {
        State = shelfLife.State.HasValue ? shelfLife.State.Value : default,
        Time = shelfLife.Time(out TimeSpan time) ? time : default,
    };
}
