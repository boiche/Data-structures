using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miscellaneous.ChangeTracker
{
    /// <summary>
    /// Marks an entity type as trackable for changes
    /// </summary>
    public abstract class TrackableEntity
    {
        /// <summary>
        /// The state of the entity
        /// </summary>
        public EntityState State { get; private set; }

        /// <summary>
        /// Indicates that there are any tracked changes
        /// </summary>
        public static bool HasChanges { get => TrackedResult.changes.Any(); }

        /// <summary>
        /// Clears all tracked changes for all trackables
        /// </summary>
        public static void ClearChanges()
            => TrackedResult.Clear();

        /// <summary>
        /// Gets all tracked changes for the current <see cref="TrackableEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>All tracked changes</returns>
        public List<Change> GetChanges()
        {
            var changes = TrackedResult.changes[this].Where(x => x.IsChanged).ToList();
            
            var nestedChanges = GetChildren(this).SelectMany(x => TrackedResult.changes[x].Where(y => y.IsChanged)).ToList();

            return changes.Concat(nestedChanges).ToList();
        }

        /// <summary>
        /// Marks current entity as <see cref="EntityState.Added"/>
        /// </summary>
        public void TrackAdded()
        {
            State = EntityState.Added;

            TrackedResult.changes.Add(this, new ChangeCollection());           
        }

        /// <summary>
        /// Marks current entity as <see cref="EntityState.Modified"/>. Entry point of tracking a change
        /// </summary>
        public void TrackModified(string propertyName, object oldValue, object newValue)
        {
            if (TrackedResult.TrackChange(this, propertyName, oldValue, newValue))
                if (this.State != EntityState.Added)
                    this.State = EntityState.Modified;
            else if (TrackedResult.changes[this].Count == 0)
                this.State = EntityState.Unchanged;
        }

        /// <summary>
        /// Marks current entity as <see cref="EntityState.Modified"/>. No change is tracked
        /// </summary>
        public void TrackModified()
            => State = EntityState.Modified;

        /// <summary>
        /// Marks current entity as <see cref="EntityState.Unchanged"/>
        /// </summary>
        public void TrackUnchanged()
            => State = EntityState.Unchanged;

        /// <summary>
        /// Marks current entity as <see cref="EntityState.Deleted"/>
        /// </summary>
        public void TrackDeleted()
        {
            if (State == EntityState.Added)
            {
                Untrack();
            }
            else
            {
                State = EntityState.Deleted;
                TrackedResult.changes.Add(this, new ChangeCollection());
            }
        }

        /// <summary>
        /// Removes current trackable from the tracker. All its changes are discarded
        /// </summary>
        public void Untrack()
            => TrackedResult.changes.Remove(this);

        /// <summary>
        /// Obtains all trackable properties for the current <see cref="TrackableEntity"/>
        /// </summary>
        /// <param name="properties"></param>
        /// <returns>All trackable properties</returns>
        private PropertyInfo[] GetTrackableProperties()
        {
            var result = new List<PropertyInfo>();

            var nestedTrackables = GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsValueType || x.PropertyType.Name == typeof(string).Name)
                .ToArray();

            while (nestedTrackables.Length != 0)
            {
                result.AddRange(nestedTrackables);
                nestedTrackables = nestedTrackables.GetNavigationProperties();
            }

            return result.ToArray();
        }

        internal static List<TrackableEntity?> GetChildren(TrackableEntity entity)
        {
            if (entity == null)
                return new List<TrackableEntity?>();

            var properties = entity
                .GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsSubclassOf(typeof(TrackableEntity)));

            var current = properties
                .Select(x => (TrackableEntity?)x.GetValue(entity))
                .Where(x => x != null);

            var currentChildren = properties
                .SelectMany(prop => GetChildren((TrackableEntity?)prop.GetValue(entity)))
                .Where(x => x != null);

            return current.Concat(currentChildren).ToList();
        }

        /// <summary>
        /// Represents all changes for current <see cref="TrackableEntity"/> in summarized string
        /// </summary>
        /// <returns></returns>
        public string ToSummary()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var property in GetTrackableProperties().OrderBy(x => x.Name))
            {
                stringBuilder.AppendLine($"\t{property.Name}: {property.GetValue(this) ?? "NULL"}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// Gets all trackables of <typeparamref name="T"/> that are <see cref="EntityState.Added"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetAdded<T>() where T : TrackableEntity
            => TrackedResult.changes.Where(x => x.Key.State == EntityState.Added && x.Key.GetType() == typeof(T)).Select(x => x.Key).Cast<T>().ToList();

        public static int TotalChanges
        { 
            get => TrackedResult.changes.Count; 
        }
        public static int TotalAdditions
        {
            get => TrackedResult.changes.Count(x => x.Key.State == EntityState.Added);
        }
        public static int TotalModifications
        {
            get => TrackedResult.changes.Count(x => x.Key.State == EntityState.Modified);
        }
        public static int TotalDeletions
        {
            get => TrackedResult.changes.Count(x => x.Key.State == EntityState.Deleted);
        }

        /// <summary>
        /// Gets all trackables of <typeparamref name="T"/> that are <see cref="EntityState.Modified"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetModified<T>() where T : TrackableEntity
            => TrackedResult.changes.Where(x => x.Key.State == EntityState.Modified && x.Key.GetType() == typeof(T)).Select(x => x.Key).Cast<T>().ToList();

        /// <summary>
        /// Gets all trackables of <typeparamref name="T"/> that are <see cref="EntityState.Deleted"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetDeleted<T>() where T : TrackableEntity
            => TrackedResult.changes.Where(x => x.Key.State == EntityState.Deleted && x.Key.GetType() == typeof(T)).Select(x => x.Key).Cast<T>().ToList();

        /// <summary>
        /// Gets all trackables of <typeparamref name="T"/> that are <see cref="EntityState.Unchanged"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetUnchanged<T>() where T : TrackableEntity
            => TrackedResult.changes.Where(x => x.Key.State == EntityState.Unchanged && x.Key.GetType() == typeof(T)).Select(x => x.Key).Cast<T>().ToList();
    }

    public static class TrackableEntityExtensions
    {
        /// <summary>
        /// Gets all <see cref="TrackableEntity"/> that have changed
        /// </summary>
        /// <param name="includeNested">Indicates that if change in navigation property has occurred, to include the entity in the result</param>
        /// <returns>All changed entities</returns>
        public static List<TrackableEntity> GetChanged(this IEnumerable<TrackableEntity> entities, bool includeNested)
        {
            var result = new List<TrackableEntity>();

            foreach (var entity in entities)
            {
                if (entity.State != EntityState.Unchanged)
                    result.Add(entity);
                else if (TrackableEntity.GetChildren(entity).Exists(x => x.State != EntityState.Unchanged) && includeNested)
                {
                    if (entity.State == EntityState.Unchanged)
                        entity.TrackModified();
                    result.Add(entity);
                }
            }

            return result;
        }

        /// <summary>
        /// Obtains all navigation properties for the current <see cref="TrackableEntity"/>
        /// </summary>
        /// <param name="properties"></param>
        /// <returns>All navigation properties</returns>
        internal static PropertyInfo[] GetNavigationProperties(this PropertyInfo[] properties)
            => properties.Where(x => x.PropertyType.IsSubclassOf(typeof(TrackableEntity))).ToArray();
    }
}
