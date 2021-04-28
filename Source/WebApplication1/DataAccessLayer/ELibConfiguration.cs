using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static class ELibConfigurations
    {
        public static string ConnectionString { get; private set; }
        public static string ProviderName { get; private set; }
        static ELibConfigurations()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            ProviderName = ConfigurationManager.ConnectionStrings["conString"].ProviderName;
        }
    }
}
