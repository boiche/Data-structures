using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.State
{
    public sealed class FuncContext<T> : IFuncStateContext
    {
        private BaseFuncState _state;
        private Type _stateType => _state.GetType();
        private Dictionary<Type, FuncStateMetaData> _statesMetaData;

        public FuncContext(BaseFuncState state)
        {
            _state = state;
            _statesMetaData = new Dictionary<Type, FuncStateMetaData>();
        }

        public void ChangeState(BaseFuncState newState)
        {
            if (!_statesMetaData.ContainsKey(_stateType))
                throw new NotSupportedException();

            this._state = newState;
        }

        public void RegisterState(BaseFuncState newState) => _statesMetaData.TryAdd(_stateType, _state.StateMetaData);
        public BaseFuncState GetState() => _state;

        public bool IsValidState() => _statesMetaData[_stateType].IsExecutable;
        public void Execute()
        {
            switch (_stateType)
            {
                case Type when _stateType == typeof(FuncDefinition):
                    {
                        //creates runtime type that represents the function (use System.Reflection.Emit builders to accomplish)
                    }
                    break;
                case Type when _stateType == typeof(FuncExecution):
                    {
                        _state.Execute();
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
