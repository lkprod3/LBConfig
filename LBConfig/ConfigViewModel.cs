using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace LBConfig
{
    class ConfigViewModel : INotifyPropertyChanged
    {
        public ConfigViewModel()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            try
            {
                using (StreamReader file = File.OpenText(Properties.Resources.ConfigJsonPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Config = (ConfigModel)serializer.Deserialize(file, typeof(ConfigModel));
                }
            } catch (FileNotFoundException)
            {
                Config = new ConfigModel();
            } catch (DirectoryNotFoundException)
            {
                Config = new ConfigModel();
            } catch(JsonException ex) when(ex.InnerException is SchemaVersionMismatchException)
            {
                MessageBox.Show(Properties.Resources.ConfigurationSchemaMismatchError);
                Application.Current.Shutdown();
            } catch(Exception)
            {
                MessageBox.Show(Properties.Resources.ConfigurationReadError);
                Config = new ConfigModel();
            }
        }

        public void SaveConfig()
        {
            Directory.CreateDirectory(Properties.Resources.LBDirectory);
            using (StreamWriter file = File.CreateText(Properties.Resources.ConfigJsonPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Config);
            }
        }

        private ConfigModel _config;
        public ConfigModel Config
        {
            get { return _config; }
            private set { _config = value; RaisePropertyChanged("Config"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
