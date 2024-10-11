using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LogisticsRestApi.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests;

public sealed class TruckAgentControllerTests
{
    const string FilePath = "Resources/sample_decide_0.json";

    private DecideRequest _request;

    // client
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        // init request from file: decide.json
        var json = File.ReadAllText(FilePath);
        // deserialize
        _request = JsonConvert.DeserializeObject<DecideRequest>(json);
        var application = new WebApplicationFactory<Program>()
           .WithWebHostBuilder(
                builder =>
                {
                    // ... Configure test services
                });

        _client = application.CreateClient();
    }

    [Test]
    public async Task Not_Empty_Offers_results_in_deliver_command()
    {
        var response = _client.PostAsJsonAsync("/decide", _request).Result;
        var responseBody = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<DeliverResponse>(responseBody);

        // ensure deliver command is returned
        Assert.AreEqual(DecisionResponseType.DELIVER.ToString(), responseObject.Command.ToString());
        Assert.AreEqual(100, responseObject.Argument);
    }
}