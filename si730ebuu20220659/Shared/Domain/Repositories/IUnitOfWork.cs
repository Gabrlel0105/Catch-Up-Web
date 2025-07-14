namespace si730ebuu20220659.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}