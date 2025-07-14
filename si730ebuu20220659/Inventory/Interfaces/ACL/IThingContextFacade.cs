namespace si730ebuu20220659.Inventory.Interfaces.ACL;

public interface IThingContextFacade
{
    Task<bool> ExistsThingAsync(Guid thingSerialNumber);
}