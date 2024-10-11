using System.Text.Json.Serialization;

namespace Logistics.Hackathon.Model;

public record Road(
    [property: JsonPropertyName("dest")] string Dest,
    [property: JsonPropertyName("km")] double Km,
    [property: JsonPropertyName("kmh")] double Kmh,
    [property: JsonPropertyName("major")] bool Major
);