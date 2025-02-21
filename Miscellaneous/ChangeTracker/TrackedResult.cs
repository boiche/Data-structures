using System;
using System.Collections.Generic;
using System.Linq;

namespace Miscellaneous.ChangeTracker
{
    /// <summary>
    /// Used as change storage. Manages tracking logic
    /// </summary>
    internal static class TrackedResult
    {
        /// <summary>
        /// Contains all tracked changes
        /// </summary>
        internal static readonly ChangeDictionary changes = new ChangeDictionary();

        /// <summary>
        /// Removes all tracked changes
        /// </summary>
        internal static void Clear() => changes.Clear();

        /// <summary>
        /// Tracks new change
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName">Property's name on which a change has occurred</param>
        /// <param name="oldValue">Property's old value</param>
        /// <param name="newValue">Property's new value</param>
        /// <returns>Whether new change is tracked successfully. No change is tracked if both values are equal</returns>
        /// <exception cref="ArgumentException"></exception>
        internal static bool TrackChange(TrackableEntity entity, string propertyName, object oldValue, object newValue)
        {
            if (string.IsNullOrEmpty(propertyName)) 
                throw new ArgumentException($"{nameof(propertyName)} cannot be null or empty");

            var property = entity.GetType().GetProperty(propertyName) ?? throw new AggregateException($"{propertyName} is not known property of {entity.GetType().Name}");

            if (oldValue == null && newValue == null)
                return false;

            if (!changes.TryGetValue(entity, out ChangeCollection? value))
            {
                changes.Add(entity, new ChangeCollection { new Change(oldValue, newValue, property) });
                return true;
            }
            else if (value.Find(x => x.PropertyName == propertyName) == default)
            {
                value.Add(new Change(oldValue, newValue, property));
                return true;
            }
            else
                return value.TryChange(propertyName, newValue);
        }
    }

    /// <summary>
    /// Contains all tracked changes of a <see cref="TrackableEntity"/>
    /// </summary>
    internal class ChangeCollection : List<Change>
    {
        /// <summary>
        /// Obtains the change of <see cref="TrackableEntity"/> for the given property name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Change GetChange(string propertyName)
            => this.First(y => y.PropertyName == propertyName);

        public void RemoveChange(string propertyName)
            => this.Remove(GetChange(propertyName));

        /// <summary>
        /// Tries to update the change related to the given property name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="newValue"></param>
        /// <returns>Whether new change is tracked successfully. No change is tracked if both values are equal</returns>
        public bool TryChange(string propertyName, object newValue)
        {
            var change = GetChange(propertyName);

            if (change.OldValue == null)
            {
                if (change.NewValue != null)
                {
                    change.NewValue = newValue;
                    return true;
                }

                RemoveChange(propertyName);
                return false;
            }
            else
            {
                if (!change.OldValue.Equals(newValue))
                {
                    change.NewValue = newValue;
                    return true;
                }

                RemoveChange(propertyName);
                return false;
            }
        }
    }

    /// <summary>
    /// Contains references of all active tracking entities and their changes
    /// </summary>
    internal class ChangeDictionary : Dictionary<TrackableEntity, ChangeCollection>
    {
        public new ChangeCollection this[TrackableEntity key] 
        {
            get
            {
                try
                {
                    return base[key];
                }
                catch (KeyNotFoundException)
                {
                    return new ChangeCollection();
                }
            }
        }

        public new void Add(TrackableEntity key, ChangeCollection value)
        {
            if (!ContainsKey(key))
                base.Add(key, value);            
        }
    }
}
