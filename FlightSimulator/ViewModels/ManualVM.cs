using FlightSimulator.Model;
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
        private ByManual model = new ByManual();

        public double Aileron
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/flight/aileron " + Convert.ToString(value));
            }
        }

        public double Elevator
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/flight/elevator " + Convert.ToString(value));
            }
        }

        public double Throttle
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/engines/current-engine/throttle " + Convert.ToString(value));
            }
        }

        public double Rudder
        {
            set
            {
                if (!ConnectAndSettingsVM.IsConnected) { return; }
                model.SendComMod("set /controls/flight/rudder " + Convert.ToString(value));
            }
        }
    }
}
