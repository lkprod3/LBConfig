using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LBConfig
{
    class ConfigModel : INotifyPropertyChanged
    {
        public ConfigModel()
        {
        }

        private GeneralConfigModel _general = new GeneralConfigModel();
        [JsonProperty("general")]
        public GeneralConfigModel General
        {
            get { return _general; }
            set { _general = value; RaisePropertyChanged("General"); }
        }
        private FmvConfigModel _fmv = new FmvConfigModel();
        [JsonProperty("fmv")]
        public FmvConfigModel Fmv
        {
            get { return _fmv; }
            set { _fmv = value; RaisePropertyChanged("Fmv"); }
        }
        private int _schemaVersion = 1;
        [JsonProperty("__schema_version")]
        public int SchemaVersion
        {
            get { return _schemaVersion; }
            set {
                if (value != 1) throw new SchemaVersionMismatchException();
                _schemaVersion = value;
                RaisePropertyChanged("SchemaVersion");
            }
        }

        public class GeneralConfigModel : INotifyPropertyChanged
        {
            private bool _fixTranslation = true;
            [JsonProperty("fixTranslation")]
            public bool FixTranslation
            {
                get { return _fixTranslation; }
                set { _fixTranslation = value; RaisePropertyChanged("FixTranslation"); }
            }
            private bool _replaceCGs = true;
            [JsonProperty("replaceCGs")]
            public bool ReplaceCGs
            {
                get { return _replaceCGs; }
                set { _replaceCGs = value; RaisePropertyChanged("ReplaceCGs"); }
            }
            private bool _improveTextDisplay = true;
            [JsonProperty("improveTextDisplay")]
            public bool ImproveTextDisplay
            {
                get { return _improveTextDisplay; }
                set { _improveTextDisplay = value; RaisePropertyChanged("ImproveTextDisplay"); }
            }
            private bool _textureFiltering = true;
            [JsonProperty("textureFiltering")]
            public bool TextureFiltering
            {
                get { return _textureFiltering; }
                set { _textureFiltering = value; RaisePropertyChanged("TextureFiltering"); }
            }
            private bool _exitBlackScreenFix = true;
            [JsonProperty("exitBlackScreenFix")]
            public bool ExitBlackScreenFix
            {
                get { return _exitBlackScreenFix; }
                set { _exitBlackScreenFix = value; RaisePropertyChanged("ExitBlackScreenFix"); }
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
        public class FmvConfigModel : INotifyPropertyChanged
        {
            private bool _enableKaraokeSubs = true;
            [JsonProperty("enableKaraokeSubs")]
            public bool EnableKaraokeSubs
            {
                get { return _enableKaraokeSubs; }
                set { _enableKaraokeSubs = value; RaisePropertyChanged("EnableKaraokeSubs"); }
            }
            private bool _enableJpVideoSubs = false;
            [JsonProperty("enableJpVideoSubs")]
            public bool EnableJpVideoSubs
            {
                get { return _enableJpVideoSubs; }
                set { _enableJpVideoSubs = value; RaisePropertyChanged("EnableJpVideoSubs"); }
            }
            private bool _useHqAudio = true;
            [JsonProperty("useHqAudio")]
            public bool UseHqAudio
            {
                get { return _useHqAudio; }
                set { _useHqAudio = value; RaisePropertyChanged("UseHqAudio"); }
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
