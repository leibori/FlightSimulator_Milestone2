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
        private ISettingsModel model = new ApplicationSettingsModel();

        //Flight server ip property.
        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        //Flight command port property.
        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        //Flight info port property.
        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

        //Save the values written in the settings window textboxes to their respective properties.
        public void SaveSettings()
        {
            model.SaveSettings();
        }

        //Reload the properties values.
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

