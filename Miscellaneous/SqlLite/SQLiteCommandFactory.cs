using System.Text;

namespace RowVersions
{
    public static class SQLiteCommandFactory
    {
        /// <summary>
        /// Generates SQLiteCommand for creating InMemory table
        /// </summary>
        /// <typeparam name="T">The type, that describes table's structure</typeparam>
        /// <param name="tableName">Name of the table</param>        
        /// <returns>Stringified 'create table' SQLiteCommand</returns>
        /// <exception cref="NotSupportedException">A collumn's type is currently unable to be matched with SQL type</exception>
        public static string CreateTable<T>()
        {
            string tableName = typeof(T).Name;
            StringBuilder builder = new();
            builder.Append($"create table {tableName} (");
            var enumerator = typeof(T).GetProperties().AsEnumerable().GetEnumerator();
            enumerator.MoveNext();
            while (true)
            {
                var current = enumerator.Current;
                switch (Type.GetTypeCode(current.PropertyType))
                {
                    case TypeCode.Boolean:
                        {
                            if (current.PropertyType == typeof(bool?))
                                builder.Append($"{current.Name} bit NULL");
                            else
                                builder.Append($"{current.Name} bit NOT NULL");
                            break;
                        }
                    case TypeCode.Int16:
                        {
                            if (current.PropertyType == typeof(short?))
                                builder.Append($"{current.Name} smallint NULL");
                            else
                                builder.Append($"{current.Name} smallint NOT NULL");
                            break;
                        }
                    case TypeCode.Int32:
                        {
                            if (current.PropertyType == typeof(int?))
                                builder.Append($"{current.Name} int NULL");
                            else
                                builder.Append($"{current.Name} int NOT NULL");
                            break;
                        }
                    case TypeCode.Int64:
                        {
                            if (current.PropertyType == typeof(long?))
                                builder.Append($"{current.Name} bigint NULL");
                            else
                                builder.Append($"{current.Name} bigint NOT NULL");
                            break;
                        }
                    case TypeCode.Decimal:
                        {
                            if (current.PropertyType == typeof(decimal?))
                                builder.Append($"{current.Name} decimal(18, 2) NULL");
                            else
                                builder.Append($"{current.Name} decimal(18, 2) NOT NULL");
                            break;
                        }
                    case TypeCode.Double:
                        {
                            if (current.PropertyType == typeof(double?))
                                builder.Append($"{current.Name} decimal(18, 2) NULL");
                            else
                                builder.Append($"{current.Name} decimal(18, 2) NOT NULL");
                            break;
                        }
                    case TypeCode.String:
                        {
                            builder.Append($"{current.Name} nvarchar(100) NULL");
                            break;
                        }
                    case TypeCode.DateTime:
                        {
                            if (current.PropertyType == typeof(DateTime?))
                                builder.Append($"{current.Name} datetime NULL");
                            else
                                builder.Append($"{current.Name} datetime NOT NULL");
                            break;
                        }
                    case TypeCode.Object:
                        {
                            if (current.PropertyType == typeof(Guid))
                                builder.Append($"{current.Name} uniqueidentifier NOT NULL");
                            else if (current.PropertyType == typeof(Guid?))
                                builder.Append($"{current.Name} uniqueidentifier NULL");
                            else
                                continue;
                            break;
                        }
                    default: throw new NotSupportedException();
                }
                if (enumerator.MoveNext())
                {
                    builder.Append(", ");
                }
                else
                {
                    builder.Append(')');
                    break;
                }
            }
            if (builder.Length == 0)
            {
                throw new InvalidOperationException($"{nameof(T)} contains no properties that can be matched with any SQL types. No table definition was created.");
            }

            return builder.ToString();
        }

        public static string SelectTable(string tableName)
        {
            var builder = new StringBuilder();

            builder.Append($"SELECT * FROM {tableName}");

            return builder.ToString();
        }

        public static string InsertTable<T>(T newObject)
        {
            string tableName = typeof(T).Name;
            if (newObject is null)
            {
                throw new ArgumentNullException(nameof(newObject));
            }
            var builder = new StringBuilder() { Capacity = 2500 };

            builder.Append($"INSERT INTO {tableName} VALUES (");
            foreach (var item in newObject.GetType().GetProperties())
            {
                var typeCode = Type.GetTypeCode(item.PropertyType);
                bool isStringifiedOject = IsSpecialDataType(item.PropertyType);
                if (typeCode == TypeCode.String || typeCode == TypeCode.Char || isStringifiedOject)
                    builder.Append($"'{item.GetValue(newObject)}',");
                else
                    builder.Append($"{item.GetValue(newObject)},");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(");");

            return builder.ToString();
        }

        private static string GetTableColumns<T>()
        {
            var builder = new StringBuilder();
            foreach (var item in typeof(T).GetProperties())
            {
                builder.Append($"{item.Name},");
            }
            builder[^1] = '\0';
            return builder.ToString();
        }

        private static bool IsSpecialDataType(Type type)
        {
            return new Type[] { typeof(Guid), typeof(DateTime), typeof(Guid?), typeof(DateTime?) }.Contains(type);
        }
    }
}
