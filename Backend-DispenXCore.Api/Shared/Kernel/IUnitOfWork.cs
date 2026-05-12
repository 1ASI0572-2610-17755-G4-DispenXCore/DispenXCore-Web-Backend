namespace Backend_DispenXCore.Api.Shared.Kernel;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}