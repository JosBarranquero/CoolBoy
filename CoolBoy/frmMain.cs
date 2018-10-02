using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CoolBoy
{
    public partial class frmMain : Form
    {
        private WebServer server;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new WebServer(SendResponse, "http://*/");

            LogInfo("Attempting to start server on *");
            try
            {
                server.Run();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                LogInfo("Server started!");
            }
            catch (Exception ex)
            {
                LogInfo(string.Format("Server start failed: {0}", ex.Message));
            }
        }

        public string SendResponse(HttpListenerRequest request)
        {
            LogInfo(string.Format("Serving {0}", request.RemoteEndPoint.Address));
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void LogInfo(string message)
        {
            if (lbLog.InvokeRequired)
            {
                lbLog.Invoke(new MethodInvoker(delegate
                {
                    lbLog.Items.Add(string.Format("[{0}] - {1}", DateTime.Now, message));
                }));
            }
            else
            {
                lbLog.Items.Add(string.Format("[{0}] - {1}", DateTime.Now, message));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            LogInfo("Server stopped");
        }
    }
}
