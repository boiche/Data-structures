using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State
{
    /// <summary>
    /// Provides methods for design-time defininition of a function 
    /// </summary>
    public class FuncDefinition : BaseFuncState
    {
        public void Define(dynamic function)
        {
            if (function is not Delegate)
            {
                throw new NotSupportedException();
            }
            base._func = function;
        }

        protected override void BeforeExecute()
        {
            base._taskStateContext.RegisterState(this);
            base.BeforeExecute();
        }

        //TODO: provide methods for structuring run-time parameters' data, return type, etc...
    }
}
