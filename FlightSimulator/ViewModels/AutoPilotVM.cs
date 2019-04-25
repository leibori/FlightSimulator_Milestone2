using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : INotifyPropertyChanged
    {
        private ByAuto model = new ByAuto();

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string color;
        public string Color
        {
            get
            {
                if (text == "") { color = "White"; }
                else { color = "Salmon"; }
                return color;
            }
        }

        private string text = "";
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                NotifyPropertyChanged("Color");
                NotifyPropertyChanged("Text");
            }
        }

        private ICommand clearButton;
        public ICommand ClearButton
        {
            get
            {
                return clearButton ?? (clearButton = new CommandHandler(() => ClearTextBox()));
            }
        }

        public void ClearTextBox()
        {
            text = "";
            NotifyPropertyChanged("Color");
            NotifyPropertyChanged("Text");
        }

        private ICommand okButton;
        public ICommand OkButton
        {
            get
            {
                return okButton ?? (okButton = new CommandHandler(() => SendCommands()));
            }
        }

        public void SendCommands()
        {
            if (!ConnectAndSettingsVM.IsConnected) { return; }
            model.SendComMod(text);
            ClearTextBox();
        }
    }
}
