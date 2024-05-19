using Com.ChristianBier.Zeiterfassung.Data.Models;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Com.ChristianBier.Zeiterfassung.Data.Services
{
    public class SqliteDataAccessService
    {

        public static List<Eintrag> LoadEintraege()
        {
            using(IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var output = con.Query<Eintrag>("SELECT id AS Id, date AS Date, time_start AS TimeStart, time_end AS TimeEnd, text AS Text FROM Eintraege;", new {});
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
