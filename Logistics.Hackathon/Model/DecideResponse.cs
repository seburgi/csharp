using System.Text.Json.Serialization;

namespace Logistics.Hackathon.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DecisionResponseType
{
    DELIVER,
    SLEEP,
    ROUTE,
}


public abstract record DecideResponse(
    DecisionResponseType Command
);

public record DeliverResponse(int Argument) : DecideResponse(DecisionResponseType.DELIVER)
{
}

public record SleepResponse(int Argument) : DecideResponse(DecisionResponseType.SLEEP)
{
}

public record RouteResponse(string Argument) : DecideResponse(DecisionResponseType.ROUTE)
{
}