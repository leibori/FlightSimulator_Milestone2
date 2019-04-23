using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualVM
    {
        private double aileron = 0;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                if (!ConnectAndSettingsVM.IsConnected) { return; }
                //send command to flight simulator
            }
        }

        private double elevator = 0;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                if (!ConnectAndSettingsVM.IsConnected) { return; }
                //send command to flight simulator
            }
        }

        private double throttle = 0;
        public double Throttle
        {
            get { return rudder; }
            set
            {
                throttle = value;
                if (!ConnectAndSettingsVM.IsConnected) { return; }
                //send command to flight simulator
            }
        }

        private double rudder = 0;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                if (!ConnectAndSettingsVM.IsConnected) { return; }
                //send command to flight simulator
            }
        }
    }
}
