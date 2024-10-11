using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record Location(
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("population")] int Population,
    [property: JsonPropertyName("roads")] List<Road> Roads);