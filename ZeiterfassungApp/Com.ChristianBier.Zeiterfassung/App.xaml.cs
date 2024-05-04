using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Com.ChristianBier.Zeiterfassung
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            if (culture.TwoLetterISOLanguageName != "de")
            {
                culture = new CultureInfo("en");
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.TwoLetterISOLanguageName);

            // Zum Testen kann die Culture Info manuell gesetzt werden
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        }
    }
}
