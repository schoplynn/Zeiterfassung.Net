using Com.ChristianBier.Zeiterfassung.Data.Interfaces;
using Com.ChristianBier.Zeiterfassung.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChristianBier.Zeiterfassung.Data.Services
{
    public class ZeitEntryService : IEntryService
    {
        public ObservableCollection<Eintrag> GetLast30Entries()
        {
            Random r = new Random();
            ObservableCollection<Eintrag> output = new ObservableCollection<Eintrag>();
            for (int i = 0; i < 30; i++)
            {
                Eintrag e = new Eintrag();
                e.Id = i;
                e.Date = DateTime.Now.AddDays(i * -1);
                e.TimeStart = new TimeOnly(i);
                e.TimeEnd = new TimeOnly(i + r.Next(24));
                e.Text = $"Eintrag {i}";
                output.Add(e);
            }
            return output;
        }
    }
}
