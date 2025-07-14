using si730ebuu20220659.Observability.Domain.Model.Commands;
using si730ebuu20220659.Observability.Interfaces.REST.Resources;

namespace si730ebuu20220659.Observability.Interfaces.REST.Transform;

public class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
    {
        return new CreateThingStateCommand(resource.SerialNumber, resource.CurrentOperationMode, resource.CurrentTemperature, resource.CurrentHumidity, resource.CollectedAt);
    }
}