namespace DesignPatterns.Behavioral.State
{
    public interface IFuncStateContext
    {
        void ChangeState(BaseFuncState state);
        void RegisterState(BaseFuncState newState);
        bool IsValidState();
        BaseFuncState GetState();
        void Execute();
    }
}
