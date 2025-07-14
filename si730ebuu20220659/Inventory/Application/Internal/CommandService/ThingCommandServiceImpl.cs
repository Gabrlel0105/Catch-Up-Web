using Cortex.Mediator.Infrastructure;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Domain.Model.Commands;
using si730ebuu20220659.Inventory.Domain.Repository;
using si730ebuu20220659.Inventory.Domain.Service;
using si730ebuu20220659.Shared.Domain.Repositories;
using IUnitOfWork = si730ebuu20220659.Shared.Domain.Repositories.IUnitOfWork;

namespace si730ebuu20220659.Inventory.Application.Internal.CommandService;

public class ThingCommandServiceImpl (IThingRepository thingRepository, IUnitOfWork unitOfWork): IThingCommandService
{
    public async Task<Thing?> Handle(CreateThingCommand command)
    {
        Guid serialNumberGuid = Guid.Parse(command.SerialNumber);
        bool thingExists = await thingRepository.ExistBySerialNumberAsync(serialNumberGuid);
        if (thingExists)
        {
            throw new Exception("Thing already exists. Code must be unique.");
        }
        
        if(command.MaximumTemperatureThreshold < -40.00m || command.MaximumTemperatureThreshold > 85.00m)
        {
            throw new Exception("MaximumTemperatureThreshold must be a decimal between -40.00 and 85.00.");
        }
        if(command.MinimumHumidityThreshold < 0.00m || command.MinimumHumidityThreshold > 100.00m)
        {
            throw new Exception("MinimumTemperatureThreshold must be a decimal between 0.00 and 100.00.");
        }
        var thing = new Thing(command);
        await thingRepository.AddAsync(thing);
        await unitOfWork.CompleteAsync();
        return thing;
    }
}