using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace chat_server
{
    public partial class GuiServer : Form
    {
        TServer server;

        public GuiServer()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // Server erzeugen
            server = new TServer(this);
            btnStartServer.Hide();
        }

        // Threadübergreifendes Schreiben in die Listbox
        delegate void InvokeDelegate(string s);

        public void showServerMessage(string msg)
        {
            if (InvokeRequired)
                BeginInvoke(new InvokeDelegate(showServerMessage), msg);
            else
                lbServer.Items.Add(msg);
        }

        private void TGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
