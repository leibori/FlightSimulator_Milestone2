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
        private Info info = new Info();
        public event PropertyChangedEventHandler PropertyChanged;

        private double lonValue;
        public double Lon
        {
            get { return lonValue; }
            set
            {
                lonValue = value;
                PropertyChangedEventArgs lonChanged = new PropertyChangedEventArgs("Lon");
                //if (PropertyChanged != null)
                //{
                    PropertyChanged?.Invoke(this, lonChanged);
                //}
            }
        }

        private double latValue;
        public double Lat
        {
            get { return latValue; }
            set
            {
                latValue = value;
                PropertyChangedEventArgs lanChanged = new PropertyChangedEventArgs("Lat");
                //if (PropertyChanged != null)
                //{
                    PropertyChanged?.Invoke(this, lanChanged);
                //}
            }
        }
      
        public bool IsConnected() { return info.isConnected; }
			

        void TaskRead()
        {
  
            new Task(delegate () {
                while (!info.isStop)
                {
                    string[] temp = info.Read();
                    string lonF = temp[0];
                    Lon = Convert.ToDouble(lonF);
                    string latF = temp[1];
                    Lat = Convert.ToDouble(latF);
                }
            }).Start();
        }

        public void ConnectionIpPort(string ip, int port)
        {
            info.Connect(ip, port);
            TaskRead();
        }

        public void IsStopUInfo() { info.isStop = true; }
    }

}
