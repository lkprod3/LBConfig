using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LBConfig
{
    enum FontFamily { NotoSans, Ubuntu, Placeholder }
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
            private bool _improveTextDisplay = true;
            [JsonProperty("improveTextDisplay")]
            public bool ImproveTextDisplay
            {
                get { return _improveTextDisplay; }
                set { _improveTextDisplay = value; RaisePropertyChanged("ImproveTextDisplay"); }
            }
            private FontFamily _font = FontFamily.NotoSans;
            [JsonProperty("font"), JsonConverter(typeof(StringEnumConverter))]
            public FontFamily Font
            {
                get { return _font; }
                set { _font = value; RaisePropertyChanged("Font"); }
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
                set
                {
                    _enableKaraokeSubs = value;
                    RaisePropertyChanged("EnableKaraokeSubs");
                    if (value == false) EnableLqKaraokeSubs = false;
                }
            }
            private bool _enableLqKaraokeSubs = false;
            [JsonProperty("enableLqKaraokeSubs")]
            public bool EnableLqKaraokeSubs
            {
                get { return _enableLqKaraokeSubs; }
                set { _enableLqKaraokeSubs = value; RaisePropertyChanged("EnableLqKaraokeSubs"); }
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
