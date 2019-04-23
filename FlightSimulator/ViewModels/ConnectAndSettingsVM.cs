using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class ConnectAndSettingsVM
    {
        private ApplicationSettingsModel settingsModel = new ApplicationSettingsModel();
        private SettingsWindow settings = new SettingsWindow();

        static private bool isConnected = false;
        static public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        public string FlightServerIP
        {
            get { return Properties.Settings.Default.FlightServerIP; }
            set { Properties.Settings.Default.FlightServerIP = value; }
        }

        public int FlightInfoPort
        {
            get { return Properties.Settings.Default.FlightInfoPort; }
            set { Properties.Settings.Default.FlightInfoPort = value; }
        }

        public int FlightCommandPort
        {
            get { return Properties.Settings.Default.FlightCommandPort; }
            set { Properties.Settings.Default.FlightCommandPort = value; }
        }

        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get { return connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClick())); }
        }
        private void ConnectClick()
        {
            if (isConnected)
            {
                //disconnect from the current server and/or client
            }
            isConnected = true;
            //create new TCP server and client with the available values (flightServerIP, flightInfoPort, flightCommandPort)
        }

        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() => SettingsClick()));
            }
        }
        private void SettingsClick()
        {
            settings.Show();
        }

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
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.Reload();
            //Close the settings window
        }
    }
}
