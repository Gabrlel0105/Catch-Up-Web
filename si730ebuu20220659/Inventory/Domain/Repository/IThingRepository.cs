namespace si730ebuu20220659.Inventory.Domain.Repository;
using si730ebuu20220659.Shared.Domain.Repositories;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
public interface IThingRepository : IBaseRepository<Thing>

//No permite que se registre dos things con el mismo valor de serialNumber
{
    Task<bool> ExistBySerialNumberAsync(Guid serialNumber);
}