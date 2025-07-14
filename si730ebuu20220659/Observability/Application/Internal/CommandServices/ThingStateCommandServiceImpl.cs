using si730ebuu20220659.Observability.Application.Internal.OutboundServices.ACL;

namespace si730ebuu20220659.Observability.Application.Internal.CommandServices;

using si730ebuu20220659.Shared.Domain.Repositories;
using si730ebuu20220659.Observability.Domain.Model.Aggregates;
using si730ebuu20220659.Observability.Domain.Model.Commands;
using si730ebuu20220659.Observability.Domain.Repository;
using si730ebuu20220659.Observability.Domain.Service;



public class ThingStateCommandServiceImpl (IThingStateRepository thingStateRepository, ExternalThingService externalThingService ,IUnitOfWork unitOfWork): ThingStateCommandService
{
    
  
    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        Guid ThingSerialNumberGuid = Guid.Parse(command.SerialNumber);
        var thing = await externalThingService.FetchThingBySerialNumber(ThingSerialNumberGuid);
        
        //“El valor UUID … debe corresponder con el serialNumber de un Thing previamente registrado.
        if (thing == null)
        {
            throw new Exception("There's no Thing with the provided Serial Number");
        }
        
        //Requiere que el valor de collectedAt no sea mayor que la fecha actual.
        if (command.CollectedAt.Date > DateTime.Now.Date)
        {
            throw new Exception("State Date cannot be in the future");
        }
        if (command.CurrentOperationMode < 0 || command.CurrentOperationMode > 2)
        {
            throw new Exception("CurrentOperationMode must be an integer between 0 and 2");
        }
        
        //No se puede agregar un Thing State con una combinación ya existente de thingSerialNumber y collectedAt.
        var existingThingState = await thingStateRepository.GetBySerialNumberAndCollectedAt(ThingSerialNumberGuid, command.CollectedAt.Date);
        if (existingThingState != null)
        {
            throw new Exception("A ThingState with the same Serial Number and CollectedAt already exists");
        }
        
        var thingState = new ThingState(command);
        await thingStateRepository.AddAsync(thingState);
        await unitOfWork.CompleteAsync();
        return thingState;
    }
}