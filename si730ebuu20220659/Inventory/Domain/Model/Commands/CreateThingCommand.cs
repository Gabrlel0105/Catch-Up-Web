namespace si730ebuu20220659.Inventory.Domain.Model.Commands;

public record CreateThingCommand (string SerialNumber,string Model,decimal MaximumTemperatureThreshold,decimal MinimumHumidityThreshold)
{
    
}