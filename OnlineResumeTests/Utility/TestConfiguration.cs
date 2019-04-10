using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineResumeTests.Utility
{
    public class TestConfiguration
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("a1f0b559-7340-4e40-95fc-731371c89692")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
