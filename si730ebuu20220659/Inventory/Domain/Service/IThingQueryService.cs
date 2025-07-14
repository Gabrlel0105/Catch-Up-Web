using si730ebuu20220659.Inventory.Domain.Model.Queries;

namespace si730ebuu20220659.Inventory.Domain.Service;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;

    
public interface IThingQueryService {
    Task<Thing> Handle(GetAllThingById query);
        
}