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
    class Commands
    {
        private TcpClient client;
        private BinaryWriter writer; // writer
        //private NetworkStream streamC;
        public bool isConnected = false;
        #region Singleton
        private static Commands _Instance = null;
        public static Commands Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Commands();
                }
                return _Instance;
            }
        }

        public bool Connected { get; internal set; }
        #endregion
        public void ComConnect(string ip, int port)
        {
            client = new TcpClient();
            IPEndPoint ipEndPo = new IPEndPoint(IPAddress.Parse(ip), port);
            while (!client.Connected)
            {
                try { client.Connect(ipEndPo); }
                catch (Exception exp)
                {
                    Console.WriteLine("pay attention to: {0}", exp.ToString());
                }
            }
            writer = new BinaryWriter(client.GetStream());
            Console.WriteLine("Connected");
            isConnected = true;
        }
        public void ComSend(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            string[] commendsList = message.Split('\n');
            foreach (string s in commendsList)
            {
                string indiCom = s + "\r\n";
                byte[] sendMess = ASCIIEncoding.ASCII.GetBytes(indiCom);
                writer.Write(sendMess, 0, sendMess.Length);
                System.Threading.Thread.Sleep(2000);
            }


        }
        public void ComClear()
        {
            _Instance = null;
        }
        public void ComClose()
        {
            client.Close();
            writer.Close();
        }

    }
}

