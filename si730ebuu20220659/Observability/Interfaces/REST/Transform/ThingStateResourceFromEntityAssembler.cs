using si730ebuu20220659.Observability.Domain.Model.Aggregates;
using si730ebuu20220659.Observability.Interfaces.REST.Resources;

namespace si730ebuu20220659.Observability.Interfaces.REST.Transform;

public class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource ToResourceFromEntity(ThingState thingState)
    {
        return new ThingStateResource(thingState.Id, thingState.SerialNumber, thingState.CurrentOperationMode,
            thingState.CurrentTemperature, thingState.CurrentHumidity, thingState.CollectedAt);
    }
}