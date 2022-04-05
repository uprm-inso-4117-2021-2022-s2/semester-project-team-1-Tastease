using Tastease.Core.Interfaces;
using Tastease.UnitTests.Collections;
using Tastease.UnitTests.Fixtures;
using Xunit;

namespace Tastease.UnitTests.Core.Services
{
    [Collection(nameof(CoreTestCollection))]
    public class IngredientServiceTests
    {
        private readonly IIngredientService _ingredientService;

        public IngredientServiceTests(ServicesFixture servicesFixture) 
        {
            _ingredientService = servicesFixture.IngredientService;
        }

        //[Theory]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public async Task GetAll_Should_When()
        //{


        //}

        //[Theory]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public async Task GetAll_Should_When()
        //{


        //}
        //[Theory]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public async Task Add_Should_When()
        //{

        //}
        //[Theory]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public async Task Add_Should_When()
        //{

        //}
        //[Theory]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        //public async Task Add_Should_When()
        //{

        //}
    }
}
