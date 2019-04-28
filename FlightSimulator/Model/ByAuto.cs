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
            // there ia connection
            ThreadConnection(s);
        }
        public void ThreadConnection(string s)
        {
            //make new thread sending commands
            new Thread(delegate () {
                Commands.Instance.ComSend(s);
            }).Start();
        }
    }
}
