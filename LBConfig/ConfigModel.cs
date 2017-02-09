using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LBConfig
{
    enum KaraokeSubsType { off, lowQuality, highQuality }

    class ConfigModel : INotifyPropertyChanged
    {
        public ConfigModel()
        {
        }

        private int _schemaVersion = 2;
        [JsonProperty("__schema_version")]
        public int SchemaVersion
        {
            get { return _schemaVersion; }
            set {
                if (value != 2) throw new SchemaVersionMismatchException();
                _schemaVersion = value;
                RaisePropertyChanged("SchemaVersion");
            }
        }

        private bool _rineBlackNames = false;
        [JsonProperty("rineBlackNames")]
        public bool RineBlackNames
        {
            get { return _rineBlackNames; }
            set { _rineBlackNames = value; RaisePropertyChanged("RineBlackNames"); }
        }
        private bool _improveDialogueOutlines = false;
        [JsonProperty("improveDialogueOutlines")]
        public bool ImproveDialogueOutlines
        {
            get { return _improveDialogueOutlines; }
            set { _improveDialogueOutlines = value; RaisePropertyChanged("ImproveDialogueOutlines"); }
        }
        private bool _hideAutoSkip = false;
        [JsonProperty("hideAutoSkip")]
        public bool HideAutoSkip
        {
            get { return _hideAutoSkip; }
            set { _hideAutoSkip = value; RaisePropertyChanged("HideAutoSkip"); }
        }
        private bool _consistency = false;
        [JsonProperty("consistency")]
        public bool Consistency
        {
            get { return _consistency; }
            set { _consistency = value; RaisePropertyChanged("Consistency"); }
        }
        private KaraokeSubsType _karaokeSubs = KaraokeSubsType.highQuality;
        [JsonProperty("karaokeSubs"), JsonConverter(typeof(StringEnumConverter))]
        public KaraokeSubsType KaraokeSubs
        {
            get { return _karaokeSubs; }
            set { _karaokeSubs = value; RaisePropertyChanged("KaraokeSubs"); }
        }
        private bool _hqFmvAudio = true;
        [JsonProperty("hqFmvAudio")]
        public bool HqFmvAudio
        {
            get { return _hqFmvAudio; }
            set { _hqFmvAudio = value; RaisePropertyChanged("HqFmvAudio"); }
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
