using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LogisticsRestApi.Model;

[JsonConverter(typeof(StringEnumConverter))]
public enum DecisionResponseType
{
    DELIVER,
    SLEEP,
    ROUTE,
}

public abstract record DecideResponse(
    DecisionResponseType Command = DecisionResponseType.SLEEP
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