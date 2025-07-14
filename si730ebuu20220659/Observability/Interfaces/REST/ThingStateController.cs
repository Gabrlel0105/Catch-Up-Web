using Microsoft.AspNetCore.Mvc;
using si730ebuu20220659.Observability.Domain.Service;
using si730ebuu20220659.Observability.Interfaces.REST.Resources;
using si730ebuu20220659.Observability.Interfaces.REST.Transform;

namespace si730ebuu20220659.Observability.Interfaces.REST;

[ApiController]
[Route("api/v1/thing-states")]
public class ThingStateController (ThingStateCommandService thingStateCommandService) : ControllerBase
{
    /// <summary>
    /// Creates a new ThingState in the database and returns the created ThingState.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateThingState(CreateThingStateResource resource)
    {
        var command = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thingState = await thingStateCommandService.Handle(command);
        var thingStateResource = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(thingState);
        return StatusCode(201, thingStateResource);
    }
    
}