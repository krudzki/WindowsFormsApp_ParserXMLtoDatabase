using MySql.Data.MySqlClient;
using System;

namespace WindowsFormsApp_ParserXMLtoDatabase
{
    internal static class DatabaseConnection
    {
        internal static MySqlConnection Create()
        {
            string connectionString = Environment.GetEnvironmentVariable(
                "XML_PARSER_MYSQL_CONNECTION_STRING");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "XML_PARSER_MYSQL_CONNECTION_STRING must be configured before using the database.");
            }
            return new MySqlConnection(connectionString);
        }
    }
}
