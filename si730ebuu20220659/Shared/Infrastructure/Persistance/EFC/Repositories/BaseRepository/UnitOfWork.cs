namespace si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Repositories.BaseRepository;
using si730ebuu20220659.Shared.Domain.Repositories;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}