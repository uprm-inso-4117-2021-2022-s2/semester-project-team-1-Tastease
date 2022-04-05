using NBomber.Configuration;
using NBomber.Contracts;
using NBomber.CSharp;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.UnitTests.Fixtures;

namespace NBomberTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceFixture = new ServicesFixture();
            var result = await serviceFixture.ApplianceService.Add(new AddApplianceRequest
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
                var response = await serviceFixture.ApplianceService.GetById(result.Value.Id);
                return response.IsSuccess
                    ? Response.Ok()
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
