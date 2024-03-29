﻿using System;
using System.Net;
using System.Threading;
using System.Text;
using System.Runtime.Remoting.Contexts;

namespace CoolBoy
{
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, byte[]> _responderMethod;

        public WebServer(string[] prefixes, Func<HttpListenerRequest, byte[]> method)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required, for example 
            // "http://localhost:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            _responderMethod = method ?? throw new ArgumentException("method");
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, byte[]> method, params string[] prefixes)
            : this(prefixes, method) { }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine("Webserver running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                byte[] buf = _responderMethod(ctx.Request);

                                if (buf == null)
                                    ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                else
                                {
                                    // Set the length of the response, write it, set the status code and flush for cleanliness
                                    ctx.Response.ContentLength64 = buf.Length;
                                    ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                                    ctx.Response.StatusCode = (int)HttpStatusCode.OK;
                                    ctx.Response.OutputStream.Flush();
                                }
                            }
                            catch // There's some error!
                            {
                                ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                throw; 
                            }
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }

        public bool Running
        {
            get
            {
                return _listener.IsListening;
            }
        }
    }
}