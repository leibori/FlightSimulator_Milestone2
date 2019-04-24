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
        static private bool isConnected = false;
        static public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
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
            SettingsWindow settings = new SettingsWindow();
            settings.ShowDialog();
        }
    }
}
