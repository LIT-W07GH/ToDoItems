using System;
using System.Data.SqlClient;

namespace ToDoItems.Models
{
    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string column)
        {
            object value = reader[column];
            if (value == DBNull.Value)
            {
                return default(T);
            }

            return (T)value;
        }
    }
}