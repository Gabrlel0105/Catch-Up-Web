using Microsoft.EntityFrameworkCore;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Repositories.BaseRepository;

namespace si730ebuu20220659.Inventory.Infrastructure.Persistance.EFC.Repositories;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Domain.Repository;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Repositories;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration;

public class ThingRepositoryImpl (AppDbContext context): BaseRepository<Thing>(context),IThingRepository

{
    public async Task<bool> ExistBySerialNumberAsync(Guid serialNumber)
    {
        return await context.Set<Thing>().AnyAsync(x => x.SerialNumberValObj.Value == serialNumber);
    }
}