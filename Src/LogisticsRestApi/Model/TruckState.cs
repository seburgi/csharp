using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record TruckState(
    [property: JsonPropertyName("uid")] int Uid,
    [property: JsonPropertyName("balance")] double Balance,
    [property: JsonPropertyName("loc")] string Loc,
    [property: JsonPropertyName("hours_since_full_rest")] double HoursSinceFullRest,
    [property: JsonPropertyName("time")] double Time
);