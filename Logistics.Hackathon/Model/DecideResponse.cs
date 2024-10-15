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
    public override string ToString() {
        return "DELIVER " + Argument;
    }
}

public record SleepResponse(int Argument) : DecideResponse(DecisionResponseType.SLEEP)
{
    public override string ToString() {
        return "SLEEP " + Argument;
    }
}

public record RouteResponse(string Argument) : DecideResponse(DecisionResponseType.ROUTE)
{
    public override string ToString() {
        return "ROUTE " + Argument;
    }
}