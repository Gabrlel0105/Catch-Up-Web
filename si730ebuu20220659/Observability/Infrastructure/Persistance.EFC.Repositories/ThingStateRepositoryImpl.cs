using Microsoft.EntityFrameworkCore;
using si730ebuu20220659.Observability.Domain.Model.Aggregates;
using si730ebuu20220659.Observability.Domain.Repository;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Repositories.BaseRepository;

namespace si730ebuu20220659.Observability.Infrastructure;


public class ThingStateRepositoryImpl (AppDbContext context): BaseRepository<ThingState>(context), IThingStateRepository
{
    public async Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt)
    {
        return await context.ThingStates
            .SingleOrDefaultAsync(ts => ts.ThingSerialNumber.Value == serialNumber && ts.CollectedAt.Date == collectedAt.Date);
    }
}