using Com.ChristianBier.Zeiterfassung.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChristianBier.Zeiterfassung.Data.Interfaces
{
    public interface IEntryService
    {
        ObservableCollection<Eintrag> GetLast30Entries();
    }
}
