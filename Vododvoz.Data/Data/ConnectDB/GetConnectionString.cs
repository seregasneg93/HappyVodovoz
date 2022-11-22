using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vododvoz.Data.Data.ConnectDB
{
    public class GetConnectionString
    {
        public string GetConnectionStrings(string connectionStringName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("Data/StringConnect/appsettings.json",
                                             optional: false,
                                             reloadOnChange: true);

            var configurationRoot = builder.Build();

            var connectionString = configurationRoot.GetConnectionString(connectionStringName);
            return connectionString;
        }
    }
}
