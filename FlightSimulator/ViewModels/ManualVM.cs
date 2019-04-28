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
        //Making the reference to the model file associated with the manual control.
        private ByManual model = new ByManual();

        //Aileron property uses the model to update the aileron value is simulator.
        public double Aileron
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/flight/aileron " + Convert.ToString(value));
            }
        }

        //Elevator property uses the model to update the elevator value is simulator.
        public double Elevator
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/flight/elevator " + Convert.ToString(value));
            }
        }

        //Throttle property uses the model to update the throttle value is simulator.
        public double Throttle
        {
            set
            {
                if (!FlightBoardViewModel.IsConnected) { return; }
                model.SendComMod("set /controls/engines/current-engine/throttle " + Convert.ToString(value));
            }
        }

        //Rudder property uses the model to update the rudder value is simulator.
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
