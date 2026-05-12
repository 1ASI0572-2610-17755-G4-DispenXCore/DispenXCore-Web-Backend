namespace Backend_DispenXCore.Api.Shared.Kernel;
public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}