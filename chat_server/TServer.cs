using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace chat_server
{
    public class TServer
    {
        public static int ServerPort = 12345;

        GuiServer gui;
        bool running;

        // Verwaltung der verbundenen Clients
        List<TConnectedClient> clientList = new List<TConnectedClient>();

        public TServer(GuiServer aGui)
        {
            gui = aGui;

            // Server starten
            running = true;
            Thread serverThread = new Thread(waitForClients);
            serverThread.Start();
        }

        public void Stop()
        {
            running = false;
        }

        void waitForClients()
        {
            // Auf dem Port lauschen
            TcpListener socket = new TcpListener(IPAddress.Any, ServerPort);
            TcpClient acceptedClient;

            socket.Start();

            gui.showServerMessage("Waiting for client connection.");

            while (running)
            {
                if (socket.Pending())
                {
                    acceptedClient = socket.AcceptTcpClient();

                    // neu akzeptierten Client im eignen Thread behandeln
                    Thread thr = new Thread(processClient);
                    thr.Start(acceptedClient);
                }
            }

            // wenn fertig, dann Liste exklusiv sperren
            lock (clientList)
            {
                // und alle Clients beenden
                foreach (TConnectedClient c in clientList)
                {
                    c.sendMessage("<q>");

                    c.Client.Close();
                }
            }
        }
        // Kommunikation mit dem Client
        public void processClient(Object clientObj)
        {
            bool clientRunning = true;

            // neuen Client in der Liste speichern
            TConnectedClient connectedClient =
                new TConnectedClient((TcpClient)clientObj);

            // Connect des neuen Clients anzeigen
            gui.showServerMessage("Connected on IP: " + connectedClient.ClientEP.Address +
                              " Port: " + connectedClient.ClientEP.Port);

            // neuen Client in Liste eintragen
            lock (clientList)
            {
                clientList.Add(connectedClient);
            }

            // Connect-Message an Client schicken
            connectedClient.sendMessage("Successfully connection to the server on port:" +
                      connectedClient.ClientEP.Port);

            // Kommunikations-Schleife
            while (clientRunning)
            {
                try
                {
                    // Warten auf Message vom Client
                    string msg = connectedClient.receiveMessage();

                    CommJson json = Newtonsoft.Json.JsonConvert.DeserializeObject<CommJson>(msg);

                    connectedClient.ClientName = json.FromC;

                    // wenn nicht "Ende"
                    if (msg != "<q>")
                    {
                        // Message im Serverfenster anzeigen
                        gui.showServerMessage(json.FromC + " : " + json.MSG + " to " + json.ToC);

                        SendMessageToClient(json);
                    }
                    else
                    {
                        clientRunning = false;
                    }
                }
                catch (Exception e)
                {
                    gui.showServerMessage("Exception: " + e.Message);
                    clientRunning = false;
                }
            }

            // Client aus der Liste entfernen
            lock (clientList)
            {
                clientList.Remove(connectedClient);
            }

            // und schließen
            connectedClient.Client.Close();

            // Schließen im Serverfenster anzeigen
            gui.showServerMessage("Connection to IP: " + connectedClient.ClientEP.Address +
                                " Port: " + connectedClient.ClientEP.Port + " closed");
        }

        private bool SendMessageToClient(CommJson json)
        {
            foreach (TConnectedClient lCient in clientList)
            {
                if (lCient.ClientName == json.ToC)
                {
                    lCient.sendMessage(Newtonsoft.Json.JsonConvert.SerializeObject(json));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

