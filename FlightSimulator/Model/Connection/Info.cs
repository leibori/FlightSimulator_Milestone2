using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Connection
{
    class Info
    {
        private TcpClient client;
        private BinaryReader reader;
        private TcpListener listener;
        public bool isStop = false;
        public bool isConnected = false;

        public string[] Read()
        {
            if (isConnected == false)
            {
                client = listener.AcceptTcpClient();
                reader = new BinaryReader(client.GetStream());
                isConnected = true;
            }

            char c;
            string s = "";
            while ((c = reader.ReadChar()) != '\n')
            {
                s += c;
            }
            string[] val = s.Split(',');
            string[] retVal = { val[0], val[1] };
            return retVal;
        }
        //connect by port and ip
        public void Connect(string ip, int port)
        {
            //if not null disconnect
            if (listener != null)
            {
                Disconnect();
            }
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("connected");
        }
        //end connection
        public void Disconnect()
        {
            isConnected = false;
            client.Close();
        }
        //stop listen
        public void Listener_Stop()
        {
            isStop = true;
            listener.Stop();
        }

    }
}
