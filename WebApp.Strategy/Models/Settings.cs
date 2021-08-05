using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Strategy.Models
{
    public class Settings
    {
        public static string ClaimDatabaseType = "databasetype";

        public EDatabaseType DatabaseType;

        public EDatabaseType GetDefaultDatabaseType => EDatabaseType.SQLServer;

    }
}
