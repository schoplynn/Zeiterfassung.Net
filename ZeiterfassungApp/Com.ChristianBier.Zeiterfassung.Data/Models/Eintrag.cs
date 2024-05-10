using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChristianBier.Zeiterfassung.Data.Models
{
    public class Eintrag : INotifyPropertyChanged
    {
        #region Data
        long _id;
        DateTime _date;
        TimeOnly _timeStart;
        TimeOnly _timeEnd;
        String _text = string.Empty;
        #endregion

        #region Properties
        public long Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public TimeOnly TimeStart { get => _timeStart; set => _timeStart = value; }
        public TimeOnly TimeEnd { get => _timeEnd; set => _timeEnd = value; }
        public string Text { get => _text; set => _text = value; }
        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
