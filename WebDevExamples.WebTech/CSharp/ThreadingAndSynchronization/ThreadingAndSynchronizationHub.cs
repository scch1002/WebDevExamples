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
        [ThreadStatic]
        private static int _value = 0;

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

        public void ThreadStaticExample()
        {
            
            var value = 0;

            var threadLocalT1 = new Thread(() =>
            {
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    Clients.Caller.ThreadStaticExample("Thread static 1: " + _value);
                    _value++;
                }
            });

            var threadLocalT2 = new Thread(() =>
            {
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    Clients.Caller.ThreadStaticExample("Thread static 2: " + _value);
                    _value++;
                }
            });

            Clients.Caller.ThreadStaticExample("Thread static example started.");
            threadLocalT1.Start();
            Thread.Sleep(12000);
            threadLocalT2.Start();
            Thread.Sleep(12000);
            Clients.Caller.ThreadStaticExample("Thread static result: " + _value);
            Clients.Caller.ThreadStaticExample("Thread static example ended.");
        }

        public void ThreadLocalTExample()
        {
            var storageT = new ThreadLocal<int>();

            var threadLocalT1 = new Thread(() =>
            {
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    Clients.Caller.ThreadLocalTExample("Thread local T 1: " + storageT.Value);
                    storageT.Value++;
                }    
            });
            
            var threadLocalT2 = new Thread(() =>
            {
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    Clients.Caller.ThreadLocalTExample("Thread local T 2: " + storageT.Value);
                    storageT.Value++;
                }
            });

            Clients.Caller.ThreadLocalTExample("Thread local T example started.");
            threadLocalT1.Start();
            Thread.Sleep(12000);
            threadLocalT2.Start();
            Thread.Sleep(12000);
            Clients.Caller.ThreadLocalTExample("Thread local T result: " + storageT.Value);
            Clients.Caller.ThreadLocalTExample("Thread local T example ended.");
        }
    }
}