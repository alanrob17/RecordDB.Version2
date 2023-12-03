using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDAL.Components
{
    internal static class DbDataReaderExtensions
    {
        public static T Field<T>(this System.Data.Common.DbDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(ordinal))
            {
                return default(T);
            }
            else
            {
                object value = reader.GetValue(ordinal);
                return (T)value;
            }
        }
    }
}
