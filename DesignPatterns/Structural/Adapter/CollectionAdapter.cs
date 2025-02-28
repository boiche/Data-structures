using RegularExpressionDataGenerator;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Structural.Adapter
{
    public static class CollectionAdapter
    {
        public static List<T> GetList<T>(this IEnumerable<T> collection)
        {
            List<T> list = new List<T>();            
            
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            return list;
        }
        public static Queue<T> GetQueue<T>(this IEnumerable<T> collection)
        {
            Queue<T> queue = new Queue<T>();
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                queue.Enqueue(enumerator.Current);
            }

            return queue;
        }
        public static Stack<T> GetStack<T>(this IEnumerable<T> collection)
        {
            Stack<T> stack = new Stack<T>();

            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                stack.Push(enumerator.Current);
            }

            return stack;
        }
        public static Dictionary<T, V> GetDictionaryWithValues<T, V>(this IEnumerable<V> collection)
        {
            Dictionary<T, V> dictionary = new Dictionary<T, V>();

            var enumerator = collection.GetEnumerator();
            bool isUnmanaged = typeof(T).IsUnmanaged();

            while (enumerator.MoveNext())
            {
                if (isUnmanaged)
                    dictionary.Add(GenerateUnmanaged<T>(), enumerator.Current);
                else
                    dictionary.Add(Generate<T>(), enumerator.Current);
            }

            return dictionary;
        }
        public static Dictionary<T, V> GetDictionaryWithKeys<T, V>(this IEnumerable<T> collection)
        {
            Dictionary<T, V> dictionary = new Dictionary<T, V>();

            var enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                dictionary.TryAdd(enumerator.Current, default(V));
            }

            return dictionary;
        }
        private static T Generate<T>() => (T)Convert.ChangeType(typeof(T).GetConstructor(BindingFlags.Default, null).Invoke(null), typeof(T));
        private static T GenerateUnmanaged<T>()
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Empty:
                case TypeCode.Object:                    
                case TypeCode.DBNull:
                    throw new NotSupportedException();
                case TypeCode.Boolean:
                    return (T)Convert.ChangeType(new Random().Next(0, 1) == 0, typeof(T));
                case TypeCode.Char:
                    return (T)Convert.ChangeType(new Random().Next(char.MinValue, char.MaxValue), typeof(T));
                case TypeCode.SByte:
                    return (T)Convert.ChangeType(new Random().Next(sbyte.MinValue, sbyte.MaxValue), typeof(T));
                case TypeCode.Byte:
                    return (T)Convert.ChangeType(new Random().Next(byte.MinValue, byte.MaxValue), typeof(T));
                case TypeCode.Int16:
                    return (T)Convert.ChangeType(new Random().Next(short.MinValue, short.MaxValue), typeof(T));
                case TypeCode.UInt16:
                    return (T)Convert.ChangeType(new Random().Next(ushort.MinValue, ushort.MaxValue), typeof(T));
                case TypeCode.Int32:
                    return (T)Convert.ChangeType(new Random().Next(int.MinValue, int.MaxValue), typeof(T));
                case TypeCode.UInt32:
                    return (T)Convert.ChangeType(new Random().Next(uint.MinValue, uint.MaxValue), typeof(T));
                case TypeCode.Int64:
                    return (T)Convert.ChangeType(new Random().Next(long.MinValue, long.MaxValue), typeof(T));
                case TypeCode.UInt64:
                    return (T)Convert.ChangeType(new Random().Next(ulong.MinValue, ulong.MaxValue), typeof(T));
                case TypeCode.Single:
                    return (T)Convert.ChangeType(new Random().Next(Single.MinValue, Single.MaxValue), typeof(T));
                case TypeCode.Double:
                    return (T)Convert.ChangeType(new Random().Next(double.MinValue, double.MaxValue), typeof(T));
                case TypeCode.Decimal:
                    return (T)Convert.ChangeType(new Random().Next(decimal.MinValue, decimal.MaxValue), typeof(T));
                case TypeCode.DateTime:
                    return (T)Convert.ChangeType(DateTime.Now, typeof(T));
                case TypeCode.String:
                    return (T)Convert.ChangeType(new RegExpDataGenerator("\\w{2, 7}").Next(), typeof(T));
                default:
                    throw new NotSupportedException();
            }
        }
        public static bool IsUnmanaged(this Type t)
        {            
            try { typeof(Temp<>).MakeGenericType(t); return true; }
            catch (Exception) { return false; }
        }
        private sealed class Temp<T> where T : unmanaged { }
    }
}
