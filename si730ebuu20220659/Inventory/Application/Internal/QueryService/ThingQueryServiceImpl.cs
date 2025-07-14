using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Domain.Model.Queries;
using si730ebuu20220659.Inventory.Domain.Repository;
using si730ebuu20220659.Inventory.Domain.Service;

namespace si730ebuu20220659.Inventory.Application.Internal.QueryService;

public class ThingQueryServiceImpl (IThingRepository thingRepository): IThingQueryService
{

    public async Task<Thing> Handle(GetAllThingById query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }
}