namespace si730ebuu20220659.Inventory.Interfaces.REST.Resources;

public record CreateThingResource (string SerialNumber, string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold)
{
    
}