using Microsoft.Extensions.Configuration;
using System.IO;

namespace FWL.Framework
{
    public enum ConfigString
    {
        BaseUrl,
        TokenUrl,
        ApiUrl
    }

    public enum ConfigInt
    {
        ResolutionWidth,
        ResolutionHeight,
        LongTimeout
    }

    internal class Config
    {
        private const string ConfigFileName = "testSettings.json";

        public static IConfiguration Configuration { get; set; }

        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigFileName);

            Configuration = builder.Build();
        }

        public static string Get(ConfigString key) => Configuration[key.ToString()];

        public static int Get(ConfigInt key) => int.Parse(Configuration[key.ToString()]);
    }
}