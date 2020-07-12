using System;
using System.Net;
using System.Windows.Forms;
using System.Reflection;

namespace CoolBoy.Forms
{
    public partial class frmMain : Form
    {
        private WebServer _server;

        #region Form constructor and events
        public frmMain()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("{0} WebServer - R{1}.{2}", Application.ProductName, version.Major, version.Minor);

            LogInfo("Application started");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void btnPref_Click(object sender, EventArgs e)
        {
            frmPreferences preferences = new frmPreferences();
            preferences.ShowDialog(this);
        }

        /// <summary>
        /// Ask to exit the application and stop the server if it's running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_server == null ? false : _server.Running)
                {
                    StopServer();
                }
                LogInfo("Exiting aplication");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tsmClearBox_Click(object sender, EventArgs e)
        {
            ClearLogBox();
        }

        private void tsmClearFile_Click(object sender, EventArgs e)
        {
            Utilities.ClearLogFile();
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog(this);
        }
        #endregion

        /// <summary>
        /// Method which logs a message to screen and file
        /// </summary>
        /// <param name="message">Message to log</param>
        private void LogInfo(string message)
        {
            string msg = string.Format("[{0}] - {1}", DateTime.Now, message);

            if (lbLog.InvokeRequired)
            {
                lbLog.Invoke(new MethodInvoker(delegate
                {
                    lbLog.Items.Add(msg);
                }));
            }
            else
            {
                lbLog.Items.Add(msg);
            }
            Utilities.Log2File(msg);
        }

        /// <summary>
        /// Clear the log box
        /// </summary>
        private void ClearLogBox()
        {
            lbLog.Items.Clear();
        }

        /// <summary>
        /// Start the server
        /// </summary>
        private void StartServer()
        {
            LogInfo("Attempting to start server on *");

            try
            {
                _server = new WebServer(SendResponse, "http://*/");
                _server.Run();
                btnStart.Enabled = false;
                btnPref.Enabled = false;
                btnStop.Enabled = true;
                LogInfo("Server started!");
            }
            catch (Exception ex)
            {
                LogInfo(string.Format("Server start failed: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        private void StopServer()
        {
            _server.Stop();
            _server = null;

            btnStart.Enabled = true;
            btnPref.Enabled = true;
            btnStop.Enabled = false;

            LogInfo("Server stopped");
        }

        /// <summary>
        /// Delegate method which will handle the server's requests
        /// </summary>
        /// <param name="request">Request being made to server</param>
        /// <returns>Response</returns>
        public string SendResponse(HttpListenerRequest request)
        {
            LogInfo(string.Format("Serving {0}", request.RemoteEndPoint.Address));
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }
    }
}
// Namespaces change, about screen