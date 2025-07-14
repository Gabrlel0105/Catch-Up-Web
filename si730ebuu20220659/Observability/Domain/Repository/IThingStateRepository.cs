using si730ebuu20220659.Observability.Domain.Model.Aggregates;
using si730ebuu20220659.Shared.Domain.Repositories;

namespace si730ebuu20220659.Observability.Domain.Repository;
//Especifica que no se puede agregar un Thing State con una combinación ya existente de
//thingSerialNumber y collectedAt.
public interface IThingStateRepository :IBaseRepository<ThingState>
{
    Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt);
}