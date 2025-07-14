using si730ebuu20220659.Inventory.Domain.Model.Commands;
using si730ebuu20220659.Inventory.Interfaces.REST.Resources;

namespace si730ebuu20220659.Inventory.Interfaces.REST.Transform;

public class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(resource.SerialNumber, resource.Model, resource.MaximumTemperatureThreshold,
            resource.MinimumHumidityThreshold);
    }
}