using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
