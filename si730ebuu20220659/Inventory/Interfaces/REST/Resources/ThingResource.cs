namespace si730ebuu20220659.Inventory.Interfaces.REST.Resources;

public record ThingResource (int Id, string SerialNumber, string Model, string OperationMode, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold)
{
    
}