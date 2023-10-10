using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;

namespace CoolBoy
{
    class Utilities
    {
        private static Utilities _myself;

        private const string LOG_FILE = "CoolBoy_{0:yyyyMMdd}.log";     // Log file filename structure
        
        private string webFolder;
        private string startPage;

        private Utilities() 
        {
			// TODO: Check if config file exists and read it or load defaults
            WebFolder = AppDomain.CurrentDomain.BaseDirectory + "Resources" + Path.DirectorySeparatorChar;
            StartPage = "index.html";
        }

        public static Utilities Instance
        {
            get
            {
                if (_myself == null)
                {
                    _myself = new Utilities();
                }

                return _myself;
            }
        }

        public string WebFolder { get => webFolder; set => webFolder = value; }
        public string StartPage { get => startPage; set => startPage = value; }

        /// <summary>
        /// Method which returns the available IPv4 addresses to set the server on
        /// </summary>
        /// <returns>The list of available addresses</returns>
        public List<string> GetLocalIPAddresses()
        {
            List<string> addresses = new List<string>();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    addresses.Add(ip.ToString());
                }
            }

            if (addresses.Count > 0)
            {
                // Add localhost and * 
                addresses.Add("localhost");
                addresses.Add("*");
                return addresses;
            }                

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        internal string Serve(string rawUrl)
        {
            string readFile = string.Empty;
            
            if (!string.IsNullOrEmpty(rawUrl))
            {
                // Getting the file name of the requested file
                // For maximum compatibility, path separator is used
                string requestedFile = rawUrl.Replace('/', Path.DirectorySeparatorChar);
                
                // Local file
                string fileName = WebFolder + Path.DirectorySeparatorChar + requestedFile;
                string[] lines;

                if (requestedFile.EndsWith(Path.DirectorySeparatorChar.ToString())) // if no file, send the default one
                    fileName += StartPage;

                if (File.Exists(fileName))      // If the file exists, read it
                    lines = File.ReadAllLines(fileName);
                else  // If the file doesn't exist, send 404 error html
                {
                    lines = new string[1];
                    lines[0] = "<!DOCTYPE html><html><head><title>404 Not Found</title></head><body><h1>Not Found</h1><p>The requested URL was not found on this server.</p></body></html>";
                    // This is hardcoded, to prevent user tampering
                }

                foreach (string line in lines)
                {
                    readFile += line + Environment.NewLine;
                }
            }

            return readFile;
        }

        /// <summary>
        /// Method which logs to a text file
        /// </summary>
        /// <param name="message">Text to log</param>
        public void Log2File(string message)
        {
            File.AppendAllText(string.Format(LOG_FILE, DateTime.Now), message + Environment.NewLine);
        }

        /// <summary>
        /// Method which purges the log file
        /// </summary>
        public void ClearLogFile()
        {
            File.WriteAllText(string.Format(LOG_FILE, DateTime.Now), "");
        }
    }
}
