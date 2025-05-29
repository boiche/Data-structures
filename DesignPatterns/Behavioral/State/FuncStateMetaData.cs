namespace DesignPatterns.Behavioral.State
{
    internal sealed class FuncStateMetaData
    {
        public bool IsDelegate { get; set; }
        public bool IsExecutable { get => IsDelegate && IsDeclared; }
        public bool IsDeclared { get; set; }
        //public BitArray Flags 
        //{ 
        //    get
        //    {
        //        return 
        //            new BitArray(this.GetType()
        //                             .GetProperties()
        //                             .Where(x => Type.GetTypeCode(x.PropertyType) == TypeCode.Boolean)
        //                             .Select(x => (bool)x.GetValue(this))
        //                             .ToArray());
        //    } 
        //}
    }
}
