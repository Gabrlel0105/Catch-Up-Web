namespace si730ebuu20220659.Observability.Domain.Service;
using si730ebuu20220659.Observability.Domain.Model.Commands;
using si730ebuu20220659.Observability.Domain.Model.Aggregates;
public interface ThingStateCommandService
{
   Task<ThingState> Handle(CreateThingStateCommand command); 
}