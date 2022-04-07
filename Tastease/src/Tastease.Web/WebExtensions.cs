using Microsoft.AspNetCore.Components;
using Tastease.Core.RecipeAggregate.PageModels;
using static Tastease.Web.PageURL;
namespace Tastease.Web;

public static class WebExtensions
{
    public static void ToIndividualCook(this NavigationManager navigationManager, CookPageModel cook) =>
        navigationManager.NavigateTo(IndividualCook(cook));
}
