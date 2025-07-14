using si730ebuu20220659.Inventory.Interfaces.REST.Resources;
using si730ebuu20220659.Inventory.Interfaces.REST.Transform;

namespace si730ebuu20220659.Inventory.Interfaces;
using Microsoft.AspNetCore.Mvc;
using si730ebuu20220659.Inventory.Domain.Model.Queries;
using si730ebuu20220659.Inventory.Domain.Service;
using si730ebuu20220659.Inventory.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class ThingController (IThingCommandService thingCommandService, IThingQueryService thingQueryService) : ControllerBase
{
    
 
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateThing(CreateThingResource resource)
    {
        var createThingCommand = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thing = await thingCommandService.Handle(createThingCommand);
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return StatusCode(201, thingResource);
    }
    
    
   
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ThingResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetThingById(int thingId)
    {
        var thing = await thingQueryService.Handle(new GetAllThingById(thingId));
        if (thing is null) return BadRequest();
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }
    
}