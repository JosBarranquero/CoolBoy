using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CoolBoy
{
    static class Utilities
    {
        private const string LOG_FILE = "CoolBoy_{0:yyyyMMdd}.log";     // Log file filename structure

        /// <summary>
        /// Method which returns the available IPv4 addresses to set the server on
        /// </summary>
        /// <returns>The list of addresses available</returns>
        public static List<string> GetLocalIPAddresses()
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

        /// <summary>
        /// Method which logs to a text file
        /// </summary>
        /// <param name="message">Text to log</param>
        public static void Log2File(string message)
        {
            File.AppendAllText(string.Format(LOG_FILE, DateTime.Now), message + "\r\n");
        }

        /// <summary>
        /// Method which purges the log file
        /// </summary>
        public static void ClearLogFile()
        {
            File.WriteAllText(string.Format(LOG_FILE, DateTime.Now), "");
        }
    }
}
