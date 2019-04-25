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
        private BinaryReader readIt;
        private TcpListener listener;
        public bool isStop = false;
        public bool isConnected = false;

        public string[] Read()
        {
            if (isConnected == false)
            {
                client = listener.AcceptTcpClient();
                readIt = new BinaryReader(client.GetStream());
                isConnected = true;
            }
            string s ="";
            s = ReadChares(readIt);
            string[] val = s.Split(',');
            string[] retVal = { val[0], val[1] };
            return retVal;
        }
        public void Connect(string ip, int port)
        {
            if (listener != null)
            {
                Disconnect();
            }
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("connected");
        }

        public void Disconnect()
        {
            isConnected = false;
            client.Close();
        }
        public void Listener_Stop()
        {
            isStop = true;
            listener.Stop();
        }
        public string ReadChares (BinaryReader b)
        {
            char c;
            string s = "";
            while ((c = readIt.ReadChar()) != '\n')
            {
                s += c;
            }
            return s;
        }

    }
}
