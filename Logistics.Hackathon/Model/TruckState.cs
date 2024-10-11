using System.Text.Json.Serialization;

namespace Logistics.Hackathon.Model;

public record TruckState(
    [property: JsonPropertyName("uid")] int Uid,
    [property: JsonPropertyName("balance")] double Balance,
    [property: JsonPropertyName("loc")] string Loc,
    [property: JsonPropertyName("hours_since_full_rest")] double HoursSinceFullRest,
    [property: JsonPropertyName("time")] double Time
);