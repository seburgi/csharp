using System.Text.Json.Serialization;

namespace Logistics.Hackathon.Model;

public record Location(
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("population")] double Population,
    [property: JsonPropertyName("roads")] List<Road> Roads);