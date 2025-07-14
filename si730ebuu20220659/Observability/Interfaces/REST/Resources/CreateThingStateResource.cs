namespace si730ebuu20220659.Observability.Interfaces.REST.Resources;

public record CreateThingStateResource( string SerialNumber, int CurrentOperationMode, decimal CurrentTemperature, decimal CurrentHumidity, DateTime CollectedAt);