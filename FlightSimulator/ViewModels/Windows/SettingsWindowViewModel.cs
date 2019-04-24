using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;

        public SettingsWindowViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

     

        public void SaveSettings()
        {
            model.SaveSettings();
        }

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        #region Commands
         private ICommand okCommand;
        public ICommand OKCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() => OKClick()));
            }
        }
        private void OKClick()
        {
            model.SaveSettings();
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new CommandHandler(() => CancelClick()));
            }
        }
        private void CancelClick()
        {
            model.ReloadSettings();
            //Close the settings window
        }
        #endregion
    }
}

