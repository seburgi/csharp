using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record DecideRequest(
    [property: JsonPropertyName("truck")] TruckState Truck, 
    [property: JsonPropertyName("offers")] ICollection<CargoOffer> Offers, 
    [property: JsonPropertyName("is_fleet")] bool IsFleet
);