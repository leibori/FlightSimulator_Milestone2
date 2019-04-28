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
        //in the model when you get a data from the simulator update the Lon (Of the plane)
        //by write in the model "Lon=..."
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
        //in the model when you get a data from the simulator update the Lat (Of the plane)
        //by write in the model "Lat=..."
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
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() => SettingsClick()));
            }
        }
        private void SettingsClick()
        {
            settings.ShowDialog();
        }

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
                return;
                model.IsStopUInfo();
                Commands.Instance.ComClose();
                Commands.Instance.ComClear();
                System.Threading.Thread.Sleep(1000);
            }
            IsConnected = true;
            connectionThread = new Thread(() => Commands.Instance.ComConnect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort));
            connectionThread.Start();
            model.ConnectionIpPort(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);
        }

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
