using System.Reflection;

namespace Miscellaneous.ChangeTracker
{
    /// <summary>
    /// Represents a single value change
    /// </summary>
    public class Change
    {
        readonly object oldValue;
        readonly string propertyName;
        public Change(object oldValue, object newValue, PropertyInfo propertyInfo)
        {
            this.oldValue = oldValue;
            this.propertyName = propertyInfo.Name;

            NewValue = newValue;
            Property = propertyInfo;
        }

        public bool IsChanged { get => OldValue != NewValue && NewValue != null; }

        public PropertyInfo Property { get; }
        public string PropertyName { get => propertyName; }
        public object OldValue { get => oldValue; }
        public object NewValue { get; internal set; }

        public override string ToString()
        {
            return $"OldValue: {OldValue}, NewValue: {NewValue}";
        }
    }
}
