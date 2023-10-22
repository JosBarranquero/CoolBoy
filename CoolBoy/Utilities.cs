using System;
using System.Collections.Generic;
using System.Configuration;
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

        private Configuration config;

        private Utilities() 
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // For maximum compatibility, directory separator is used
            try
            {
                webFolder = config.AppSettings.Settings["WebFolder"].Value;
                startPage = config.AppSettings.Settings["StartPage"].Value;
            }
            catch (NullReferenceException)  // Issue loading the file (it doesn't exist)
            {
                CreateConfigFile();     // Create the configuration file
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);    // reload

                webFolder = ""; // set default which will be overwritten later
                startPage = "";

            } 
            finally     // always check for default values
            {
                if (WebFolder.Equals(""))
                {
                    WebFolder = AppDomain.CurrentDomain.BaseDirectory + "Resources" + Path.DirectorySeparatorChar;
                }

                if (StartPage.Equals(""))
                {
                    StartPage = "index.html";
                }
            }
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

        public string WebFolder 
        { 
            get => webFolder; 
            
            set // Save the setting to file as well
            {
                webFolder = value;
                config.AppSettings.Settings["WebFolder"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            } 
        }

        public string StartPage
        {
            get => startPage;

            set // Save the setting to file as well
            {
                startPage = value;
                config.AppSettings.Settings["StartPage"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

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
                // For maximum compatibility, directory separator is used
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

        /// <summary>
        /// Method which creates a Configuration File with default settings
        /// </summary>
        private void CreateConfigFile()
        {
            string fileName = AppDomain.CurrentDomain.FriendlyName + ".Config";
            string fileContents = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<configuration>" + Environment.NewLine +
                "    <startup>" + Environment.NewLine +
                "        <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.8\"/>" + Environment.NewLine +
                "    </startup>" + Environment.NewLine +
                "    <appSettings>" + Environment.NewLine +
                "        <add key=\"WebFolder\" value=\"\" />" + Environment.NewLine +
                "        <add key=\"StartPage\" value=\"\" />" + Environment.NewLine +
                "    </appSettings> " + Environment.NewLine +
                "</configuration>";
            File.WriteAllText(fileName, fileContents);
        }
    }
}
