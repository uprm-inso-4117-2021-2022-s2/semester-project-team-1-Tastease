using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.UnitTests.Collections;
using Tastease.UnitTests.Fixtures;
using Xunit;

namespace Tastease.UnitTests.Core.Services
{
    [Collection(nameof(CoreTestCollection))]
    public class ApplianceServiceTests
    {
        private readonly InMemoryDatabaseFixture _databaseFixture;
        private readonly IApplianceService _applianceService;

        public ApplianceServiceTests(InMemoryDatabaseFixture databaseFixture, ServicesFixture servicesFixture) 
        {
            _databaseFixture = databaseFixture;
            _applianceService = servicesFixture.ApplianceService;
        }
        [Theory]
        [InlineData()]
        public void GetAll_Should_When() //TODO: Complete
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void Delete_Should_When()
        {

            //Arrange
            var applianceToDelete = _databaseFixture.CoreContext.Appliances.Add(new ApplianceTable
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Guid = Guid.NewGuid().ToString()
            }).Entity;
            _databaseFixture.CoreContext.SaveChanges();
            _databaseFixture.CoreContext.Appliances.Where(appliance => appliance.Guid == applianceToDelete.Guid).Count().Should().Be(1);
            var applianceId = new ApplianceId(Guid.Parse(applianceToDelete.Guid));
            //Act
            var deletedApplianceResult = await _applianceService.Delete(applianceId);
            //Assert
            deletedApplianceResult.IsSuccess.Should().BeTrue();
            deletedApplianceResult.Errors.Should().BeEmpty();
            deletedApplianceResult.Value.Name.Should().Be(applianceToDelete.Name);
            deletedApplianceResult.Value.Id.Should().Be(applianceId);
            deletedApplianceResult.Value.Description.Should().Be(applianceToDelete.Description);
            _databaseFixture.CoreContext.Appliances.Where(appliance => appliance.Guid == applianceToDelete.Guid).Count().Should().Be(0);
        }
        [Theory]
        [InlineData("Blender", "Ninja")]
        [InlineData("Toaster", "pretty one")]
        [InlineData("Spoon", "rusted")]
        [InlineData("Fork", "clean")]
        [InlineData("Table", "4 seater")]
        [InlineData("Knife", "high end cutting edge cool stuff")]
        [InlineData("Cup", "made of glass and stuff")]
        public async Task Add_ShouldBeSucceful_WhenGivenAValidAppliance(string name, string description)
        {
            //Precodition
            _databaseFixture.CoreContext.Appliances.Where(appliance => appliance.Name == name).Count().Should().Be(0);
            //Arrange
            var applianceToAdd = new AddApplianceRequest
            {
                Name = name,
                Description = description
            };
            //Act
            var addedApplianceResult = await _applianceService.Add(applianceToAdd);
            //Assert
            addedApplianceResult.Errors.Should().BeEmpty();
            addedApplianceResult.IsSuccess.Should().BeTrue();
            addedApplianceResult.Value.Should().NotBeNull();
            addedApplianceResult.Value.Description.Should().Be(description);
            addedApplianceResult.Value.Name.Should().Be(name);
            addedApplianceResult.Value.Id.Should().NotBeNull();
            _databaseFixture.CoreContext.Appliances.Where(appliance => appliance.Name == name).Count().Should().Be(1);
        }
        [Theory]
        [InlineData("", "Ninja")]
        [InlineData(null, "Ninja")]
        [InlineData("Spatula", "")]
        [InlineData("Grill", null)]
        public async void Add_ShouldBeUnsucceful_WhenGivenAInvalidAppliance(string name, string description)
        {
            //Arrange
            var applianceToAdd = new AddApplianceRequest
            {
                Name = name,
                Description = description
            };
            try 
            {
                //Act
                var addedApplianceResult = await _applianceService.Add(applianceToAdd);

                //Assert
                addedApplianceResult.ValidationErrors.Should().NotBeEmpty();
                addedApplianceResult.IsSuccess.Should().BeFalse();
                addedApplianceResult.Value.Should().BeNull();
            }
            catch (Exception ex) 
            {
                ex.GetType().Should().Be(typeof(DbUpdateException));
            }
            
        }
        //[Fact]
        //public async Task Add_ShouldBeUnsucceful_WhenGivenAnAlreadyExistingAppliance()//TODO: Fix
        //{
        //    //Precodition
        //    _databaseFixture.CoreContext.Appliances.Count().Should().BeGreaterThan(0);
        //    //Arrange
        //    var existingAppliance = _databaseFixture.CoreContext.Appliances.First();
        //    var applianceToAdd = new AddApplianceRequest
        //    {
        //        Name = existingAppliance.Name,
        //        Description = existingAppliance.Description,
        //    };
        //    //Act
        //    var addedApplianceResult = await _applianceService.Add(applianceToAdd);
        //    //Assert
        //    addedApplianceResult.ValidationErrors.Should().NotBeEmpty();
        //    addedApplianceResult.IsSuccess.Should().BeFalse();
        //    _databaseFixture.CoreContext.Appliances.Where(appliance => appliance.Name == existingAppliance.Name).Count().Should().Be(1);
        //}
        [Fact]
        public async void GetById_Should_When()
        {
            //Precodition
            _databaseFixture.CoreContext.Appliances.Count().Should().BeGreaterThan(0);
            //Arrange
            var existingAppliance = _databaseFixture.CoreContext.Appliances.First();
            var applianceId = new ApplianceId(Guid.Parse(existingAppliance.Guid));
            //Act
            var applianceResult = await _applianceService.GetById(applianceId);
            //Assert
            applianceResult.Errors.Should().BeEmpty();
            applianceResult.IsSuccess.Should().BeTrue();
            applianceResult.Value.Should().NotBeNull();
            applianceResult.Value.Description.Should().Be(existingAppliance.Description);
            applianceResult.Value.Name.Should().Be(existingAppliance.Name);
            applianceResult.Value.Id.Should().Be(applianceId);
        }
    }
}
