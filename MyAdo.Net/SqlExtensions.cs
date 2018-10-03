using System;
using System.Data.SqlClient;

namespace MyAdo.Net
{
    public static class SqlExtensions
    {
        public static Guid GetGuidSafe(this SqlDataReader reader, string columnName)
        {
            var res = reader[reader.GetOrdinal(columnName)];
            if (res == null)
            {
                return default(Guid);
            }

            if (Guid.TryParse(res.ToString(), out Guid parsedGuid))
            {
                return parsedGuid;
            }

            return default(Guid);
        }

        public static string GetStringSafe(this SqlDataReader reader, string columnName)
        {
            var res = reader[reader.GetOrdinal(columnName)] as string;
            if (res == null)
            {
                return default(string);
            }

            return res;
        }
    }
}
