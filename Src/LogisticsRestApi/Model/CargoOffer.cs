using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record CargoOffer(
    [property: JsonPropertyName("uid")] int Uid,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("origin")] string Origin,
    [property: JsonPropertyName("dest")] string Dest,
    [property: JsonPropertyName("price")] double Price,
    [property: JsonPropertyName("eta_to_cargo")] double EtaToCargo,
    [property: JsonPropertyName("km_to_cargo")] double KmToCargo,
    [property: JsonPropertyName("eta_to_deliver")] double EtaToDeliver,
    [property: JsonPropertyName("km_to_deliver")] double KmToDeliver
);