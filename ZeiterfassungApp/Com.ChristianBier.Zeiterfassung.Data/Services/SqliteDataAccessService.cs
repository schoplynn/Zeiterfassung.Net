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
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var output = con.Query<Eintrag>("SELECT id AS Id, date AS Date, time_start AS TimeStart, time_end AS TimeEnd, text AS Text FROM Eintraege;", new { });
                return output.ToList();
            }
        }

        public static bool SaveEintag(Eintrag eintrag)
        {
            bool output = false;
            int affectedRows = 0;
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                if (eintrag.Id > 0)
                {
                    affectedRows = con.Execute("UPDATE Eintraege SET date = @DateInput, time_start = @TimeStart, time_end = @TimeEnd, text = @TextInput WHERE id = @Id;", new { DateInput = eintrag.Date, TimeStart = eintrag.TimeStart.ToString("HH:mm"), TimeEnd = eintrag.TimeEnd.ToString("HH:mm"), TextInput = eintrag.Text, Id = eintrag.Id });
                }
                else
                {
                    affectedRows = con.Execute("INSERT INTO Eintraege (date, time_start, time_end, text) VALUES (@DateInput, @TimeStart, @TimeEnd, @TextInput);", new { DateInput = eintrag.Date, TimeStart = eintrag.TimeStart.ToString("HH:mm"), TimeEnd=eintrag.TimeEnd.ToString("HH:mm"), TextInput = eintrag.Text});
                }
            }
            if (affectedRows > 0)
            {
                output = true;
            }
            return output;
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
