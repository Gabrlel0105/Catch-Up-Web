namespace si730ebuu20220659.Inventory.Interfaces.ACL.Services;
using si730ebuu20220659.Inventory.Domain.Repository;
public class ThingContextFacade (IThingRepository thingRepository) : IThingContextFacade

{
    
    /// <summary>
    /// Implementation of ExistsThingAsync
    /// </summary>
    /// <param name="serialNumber"></param>
    /// <returns></returns>
    public async Task<bool> ExistsThingAsync(Guid serialNumber)
    {
        return await thingRepository.ExistBySerialNumberAsync(serialNumber);
    }
}