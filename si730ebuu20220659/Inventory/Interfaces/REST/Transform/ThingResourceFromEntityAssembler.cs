using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Interfaces.REST.Resources;

namespace si730ebuu20220659.Inventory.Interfaces.REST.Transform;

public class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing entity)
    {
        return new ThingResource(entity.Id, entity.SerialNumber, entity.Model, entity.OperationMode, entity.MaximumTemperatureThreshold, entity.MinimumHumidityThreshold);
    }
}