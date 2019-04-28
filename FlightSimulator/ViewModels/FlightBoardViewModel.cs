using FlightSimulator.Model;
using FlightSimulator.Model.Connection;
using FlightSimulator.Views.Windows;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        #region Singleton
        private static FlightBoardViewModel _Instance = null;
        public static FlightBoardViewModel Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FlightBoardViewModel();
             
                }
                return _Instance;
            }
        }
        #endregion 
        private ByFlyBoard model = new ByFlyBoard();
        private SettingsWindow settings = new SettingsWindow();
        private Thread connectionThread;

        public FlightBoardViewModel()
        {
            model.PropertyChanged += dataRec;
        }

        private static double lon;
        //In the model when you get a data from the simulator update the Lon (Of the plane)
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private static double lat;
        //In the model when you get a data from the simulator update the Lat (Of the plane)
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private ICommand settingsCommand;
        //Activated after pressing the "settings" button.
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() => SettingsClick()));
            }
        }
        //As a result of pressing the "settings" button the settings window appears.
        private void SettingsClick()
        {
            settings.ShowDialog();
        }

        //Property to know whether or not there's connection.
        static private bool isConnected = false;
        static public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

         //Activated after pressing the "disconnect" button.
        private ICommand disconnectCommand;
        public ICommand DisonnectCommand
        {
            get { return connectCommand ?? (connectCommand = new CommandHandler(() => DisconnectClick())); }
        }
        //As a result of pressing the "disconnect" button the model disconnects from the flight simulator.
        private void DicsonnectClick()
        {
            if (!isConnected) { return; }
            model.StopInfo();
            CommandBinding.Instance.ComClose();
            CommandBinding.Instance.ComClear();
        }

        //Activated after pressing the "connect" button.
        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get { return connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClick())); }
        }
        //As a result of pressing the "connect" button the model attempts to connect to the flight simulator.
        private void ConnectClick()
        {
            if (isConnected) { return; }
            IsConnected = true;
            connectionThread = new Thread(() => Commands.Instance.ComConnect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort));
            connectionThread.Start();
            model.ConnectionIpPort(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);
        }

        //Listens to the model for changes in longitude and latitude.
        public void dataRec(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat"))
            {
                Lat = model.Lat;
            }

            if (e.PropertyName.Equals("Lon"))
            {
                Lon = model.Lon;
            }
        }
    }
}
