using NBomber.Configuration;
using NBomber.Contracts;
using NBomber.CSharp;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.Core.RecipeAggregate.Validators;
using Tastease.Core.Services;
using Tastease.Infrastructure.Data;
using Tastease.Infrastructure.Data.CoreContext;

namespace NBomberTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var applianceService = new ApplianceService(
                    new EfRepository<ApplianceTable>(new CoreDbContext()),
                    new AddApplianceRequestValidator(),
                    new BasePaginationRequestValidator());
            var result = await applianceService.Add(new AddApplianceRequest
            {
                Name = "Pencil",
                Description = "Sharp"
            });
            if (!result.IsSuccess)
            {
                throw new Exception("Failed");
            }
            var step = Step.Create("fetch_appliances", async context =>
            {
                var applianceService = new ApplianceService(
                    new EfRepository<ApplianceTable>(new CoreDbContext()),
                    new AddApplianceRequestValidator(),
                    new BasePaginationRequestValidator());
                var response = await applianceService.GetById(result.Value.Id);
                return response.IsSuccess
                    ? Response.Ok(response)
                    : Response.Fail();
            });
            var scenario = ScenarioBuilder.CreateScenario("fetch_appliances_scenario", step)
               .WithWarmUpDuration(TimeSpan.FromSeconds(60))
               .WithLoadSimulations(
                   Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromMinutes(10))
            );
            NBomberRunner
              .RegisterScenarios(scenario)
              .WithReportFileName("fetch_appliances_report")
              .WithReportFolder("fetch_appliances_reports")
              .WithReportFormats(ReportFormat.Txt, ReportFormat.Csv, ReportFormat.Html, ReportFormat.Md)
              .Run();
        }
    }
}
