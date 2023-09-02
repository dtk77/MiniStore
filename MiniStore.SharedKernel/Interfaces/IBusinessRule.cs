namespace MiniStore.SharedKernel.Interfaces
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
