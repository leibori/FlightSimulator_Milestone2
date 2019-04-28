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
        //Color property associated with the auto pilot textbox background color.
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
        //Text property associated with the auto pilot textbox content.
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
        //Activated after pressing the "clear" button.
        public ICommand ClearButton
        {
            get
            {
                return clearButton ?? (clearButton = new CommandHandler(() => ClearTextBox()));
            }
        }
        //As a result of pressing the "clear" button the auto pilot textbox content is cleared and notify both properties of the change.
        public void ClearTextBox()
        {
            text = "";
            NotifyPropertyChanged("Color");
            NotifyPropertyChanged("Text");
        }

        private ICommand okButton;
        //Activated after pressing the "ok" button.
        public ICommand OkButton
        {
            get
            {
                return okButton ?? (okButton = new CommandHandler(() => SendCommands()));
            }
        }
        //As a result of pressing the "ok" button the auto pilot textbox content is sent through the model to the simulator.
        public void SendCommands()
        {
            if (!FlightBoardViewModel.IsConnected) { return; }
            model.SendComMod(text);
            ClearTextBox();
        }
    }
}
