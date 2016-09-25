using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LBConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DiscardExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            ConfigViewModel cfg = (ConfigViewModel)DataContext;
            cfg.LoadConfig();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ConfigViewModel cfg = (ConfigViewModel)DataContext;
            try
            {
                cfg.SaveConfig();
            } catch(Exception)
            {
                MessageBox.Show(Properties.Resources.ConfigurationSaveError);
            }
        }

        private void SaveExit_Click(object sender, RoutedEventArgs e)
        {
            ConfigViewModel cfg = (ConfigViewModel)DataContext;
            try
            {
                cfg.SaveConfig();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.ConfigurationSaveError);
                return;
            }
            System.Diagnostics.Process.Start(Properties.Resources.RunGameUri);
            Application.Current.Shutdown();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
