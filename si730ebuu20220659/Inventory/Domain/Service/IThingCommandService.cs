using si730ebuu20220659.Observability.Domain.Model.Commands;

namespace si730ebuu20220659.Inventory.Domain.Service;
using si730ebuu20220659.Inventory.Domain.Model.Commands;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
public interface IThingCommandService
{
    Task<Thing> Handle(CreateThingCommand command);
}