using FlightSimulator.Model.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ByFlyBoard
    {
        //  server updating  lon and lat values
        private Info info = new Info();
        // event notifier
        public event PropertyChangedEventHandler PropertyChanged;
        private double lonValue;
        // property of lon
        public double Lon
        {
            get { return lonValue; }
            set
            {
                lonValue = value;
                //notify the view model  
                PropertyChangedEventArgs lonChanged = new PropertyChangedEventArgs("Lon");
                    PropertyChanged?.Invoke(this, lonChanged);
            }
        }

        private double latValue;
        // property of lon
        public double Lat
        {
            get { return latValue; }
            set
            {
                latValue = value;
                //notify the view model  
                PropertyChangedEventArgs lanChanged = new PropertyChangedEventArgs("Lat");         
                    PropertyChanged?.Invoke(this, lanChanged);
            }
        }
      
        public bool IsConnected() { return info.isConnected; }
        // server reading 
        void TaskRead()
        {
            //open task
            new Task(delegate () {
                while (!info.isStop)
                {
                    // converts to doubles from string
                    string[] temp = info.Read();
                    string lonF = temp[0];
                    Lon = Convert.ToDouble(lonF);
                    string latF = temp[1];
                    Lat = Convert.ToDouble(latF);
                }
            }).Start();
        }
        //handle info
        public void ConnectionIpPort(string ip, int port)
        {
            info.Connect(ip, port);
            TaskRead();
        }

        public void IsStopUInfo() { info.isStop = true; }
    }
}
