using FlightSimulator.Model.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ByAuto
    {
        public void SendComMod(string s)
        {
            new Thread(delegate () {
                Commands.Instance.ComSend(s);
            }).Start();
        }
    }
}
