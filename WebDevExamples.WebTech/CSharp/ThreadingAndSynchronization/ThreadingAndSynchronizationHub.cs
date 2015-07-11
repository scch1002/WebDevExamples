using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.ThreadingAndSynchronization
{
    public class ThreadingAndSynchronizationHub : Hub
    {
        public void SimpleThreadingExample()
        {
            var simpleThread = new Thread(() =>
            {
                Clients.Caller.SimpleThreadingExample("Simple threading example has started.");
                for (var count = 0; count <= 5; count++)
                {
                    Thread.Sleep(2000);
                    Clients.Caller.SimpleThreadingExample("Simple Threading Example: " + count);
                }
                Thread.Sleep(2000);
                Clients.Caller.SimpleThreadingExample("Simple threading example has ended.");
            });
            simpleThread.Start();
        }
    }
}