using System;

namespace Unite.Identity.Migrations.Configuration
{
    public static class EnvironmentConfig
    {
        private static string _defaultSqlHost = "localhost";
        private static string _defaultSqlPort = "5432";
        private static string _defaultSqlUser = "root";
        private static string _defaultSqlPassword = "Long-pa55w0rd";

        public static string SqlHost => GetEnvironmentVariable("UNITE_SQL_HOST", _defaultSqlHost);
        public static string SqlPort = GetEnvironmentVariable("UNITE_SQL_PORT", _defaultSqlPort);
        public static string SqlUser => GetEnvironmentVariable("UNITE_SQL_USER", _defaultSqlUser);
        public static string SqlPassword = GetEnvironmentVariable("UNITE_SQL_PASSWORD", _defaultSqlPassword);

        private static string GetEnvironmentVariable(string variable, string defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(variable);

            return value ?? defaultValue;
        }
    }
}
