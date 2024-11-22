using Microsoft.Extensions.Configuration;


namespace hospmanagement.Utility
{
    internal static class DbConnUtil
    {
        private static IConfiguration _iconfiguration;

        static DbConnUtil()
        {
            GetAppSettingsFile();
        }


        private static void GetAppSettingsFile()
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            string connString = configuration.GetConnectionString("DefaultConnection");
        }

        public static string GetConnectionString()
        {
           return _iconfiguration.GetConnectionString("LocalConnectionString");
        }


    }
}

