using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Logistics.Hackathon.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Logistics.Hackathon.Tests;

public sealed class Tests
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

    [Test]
    public async Task Can_Load_Map_Locations()
    {
        var locations = HackathonMap.Locations;
        Assert.AreEqual(89, locations.Count);

        Assert.AreEqual("Berlin", locations[0].City);
        Assert.AreEqual("Germany", locations[0].Country);
        Assert.AreEqual(52.5167, locations[0].Lat);
        Assert.AreEqual(13.3833, locations[0].Lng);
    }
}