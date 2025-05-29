using System;

namespace DesignPatterns.Behavioral.State
{
    public abstract class BaseFuncState
    {
        protected IFuncStateContext _taskStateContext { get; set; }
        protected dynamic _func;

        internal FuncStateMetaData StateMetaData
        {
            get
            {
                return new FuncStateMetaData()
                {
                    IsDelegate = _func is Delegate,
                    IsDeclared = (_func as Delegate).Method.DeclaringType.HasElementType
                };
            }
        }

        public event EventHandler OnBeforeExecute;
        public event EventHandler OnAfterExecute;

        protected virtual void BeforeExecute()
        {
            _taskStateContext.ChangeState(this);
            OnBeforeExecute(this, EventArgs.Empty);
        }

        protected virtual void AfterExecute()
        {
            OnAfterExecute(this, EventArgs.Empty);
        }

        public virtual void Execute()
        {
            var currentState = _taskStateContext.GetState();

            currentState.BeforeExecute();
            if (_taskStateContext.IsValidState())
                currentState.Execute();
            currentState.AfterExecute();
        }
    }
}
