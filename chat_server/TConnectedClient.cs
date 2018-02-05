using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace chat_server
{
    // Hilfsklasse zum verwalten der verbundenen Threads im Server
    class TConnectedClient
    {
        public TcpClient Client { get; private set; }
        public String ClientName { get; set; }
        public StreamWriter Writer { get; private set; }
        public StreamReader Reader { get; private set; }
        public IPEndPoint ClientEP { get; private set; }

        public TConnectedClient(TcpClient aClient)
        {
            Client = aClient;
            Writer = new StreamWriter(Client.GetStream());
            Reader = new StreamReader(Client.GetStream());
            ClientEP = (IPEndPoint)Client.Client.RemoteEndPoint;
        }

        public void sendMessage (string msg)
        {
            Writer.WriteLine(msg);
            Writer.Flush();
        }

        public string receiveMessage()
        {
            return Reader.ReadLine();
        }
    }
}
