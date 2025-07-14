namespace si730ebuu20220659.Observability.Application.Internal.OutboundServices.ACL;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Domain.Model.ValueObjects;
using si730ebuu20220659.Inventory.Interfaces.ACL;

public class ExternalThingService (IThingContextFacade thingContextFacade)

{
    public async Task<SerialNumber?> FetchThingBySerialNumber(Guid serialNumber)
    {
        bool thingExists = await thingContextFacade.ExistsThingAsync(serialNumber);
        if (thingExists)
        {
            return new SerialNumber(serialNumber);
        }
        else
        {
            return null;
        }
    }
}