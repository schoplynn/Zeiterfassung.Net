﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Com.ChristianBier.Zeiterfassung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonButtonEntryAdd_Click(object sender, RoutedEventArgs e)
        {
            EntryDetailWindow edw = new EntryDetailWindow();
            edw.Owner = this;
            edw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            edw.ShowDialog();
        }
    }
}
