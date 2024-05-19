using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Com.ChristianBier.Zeiterfassung.Data.Models
{
    public class Eintrag : INotifyPropertyChanged
    {
        #region Data
        long _id;
        DateTime _date;
        DateTime _timeStart;
        DateTime _timeEnd;
        String _text = string.Empty;
        #endregion

        #region Properties
        public long Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public DateTime Date { get => _date; set { _date = value; OnPropertyChanged(); } }
        public DateTime TimeStart { get => _timeStart; set { _timeStart = value; OnPropertyChanged(); } }
        public DateTime TimeEnd { get => _timeEnd; set { _timeEnd = value; OnPropertyChanged(); } }
        public string Text { get => _text; set { _text = value; OnPropertyChanged(); } }
        public TimeSpan Dauer
        {
            get
            {
                return (TimeEnd - TimeStart);
            }
        }
        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
