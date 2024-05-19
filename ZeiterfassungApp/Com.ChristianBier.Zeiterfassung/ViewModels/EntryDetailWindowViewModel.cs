using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Com.ChristianBier.Zeiterfassung.Data.Interfaces;
using Com.ChristianBier.Zeiterfassung.Data.Models;

namespace Com.ChristianBier.Zeiterfassung.ViewModels
{
    public class EntryDetailWindowViewModel : INotifyPropertyChanged
    {

        #region Data
        Eintrag _eintrag = new Eintrag();
        IEntryService _entryService;
        string _windowTitle = "Neuer Eintrag";
        #endregion

        #region Properties
        public Eintrag Eintrag { get => _eintrag; set { _eintrag = value; OnPropertyChanged(); } }

        public string WindowTitle { get => _windowTitle; set { _windowTitle = value; OnPropertyChanged(); } }
        #endregion

        #region Constructors
        public EntryDetailWindowViewModel(IEntryService entryService)
        {
            _entryService = entryService;
            Eintrag = new Eintrag() { Date = DateTime.Now, TimeEnd = DateTime.Now, TimeStart = DateTime.Now, Text = "Hallo Welt" };
        }
        #endregion

        #region Methods
        public void Save()
        {
            _entryService.Save(Eintrag);
        }
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
