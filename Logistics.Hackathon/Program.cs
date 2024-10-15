using System.Text.Json.Serialization;
using Logistics.Hackathon.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument(configure =>
{
    configure.Title = "Hackathon API";
    configure.Version = "v1";
    configure.Description = "API for the Hackathon";
});
builder.Services
    .Configure<JsonOptions>(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();
app.UseOpenApi();

// Configure the HTTP request pipeline.
app.UseSwaggerUi3(configure =>
{
    configure.DocExpansion = "list";
});

app.MapGet("/health", async () =>
    {
        app.Logger.LogInformation("Health request received");
        return Results.Ok();
    })
    .WithName("Health check")
    .WithOpenApi();

app.MapPost("/decide", async (DecideRequest request) =>
    {
        // TODO: CHANGE THE CODE BELOW DURING THE HACKATHON

        app.Logger.LogInformation("Received DecideRequest");
        var firstOffer = request.Offers.FirstOrDefault();


        DecideResponse response = firstOffer != null ? new DeliverResponse(firstOffer.Uid) : new SleepResponse(1);
        app.Logger.LogInformation("Response: {response}", response);
        
        return Results.Ok(response);

        // TODO: CHANGE THE CODE ABOVE DURING THE HACKATHON
    })
    .WithName("Handle DecideRequest from Hackathon framework")
    .Produces<DeliverResponse>()
    .WithOpenApi();


app.Run();