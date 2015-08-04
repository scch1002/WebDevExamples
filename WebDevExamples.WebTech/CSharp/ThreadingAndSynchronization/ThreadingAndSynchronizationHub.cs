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

        public void ThreadLocalStorageExample()
        {
            Thread.AllocateNamedDataSlot("Value");
            
            var threadLocalStorage1 = new Thread(() =>
            {
                var slotThread1 = Thread.GetNamedDataSlot("Value");
                Thread.SetData(slotThread1, 0);
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    var value = (int)Thread.GetData(slotThread1);
                    Clients.Caller.ThreadLocalStorageExample("Thread local storage 1: " + value);
                    value++;
                    Thread.SetData(slotThread1, value);
                }
            });

            var threadLocalStorage2 = new Thread(() =>
            {
                var slotThread2 = Thread.GetNamedDataSlot("Value");
                Thread.SetData(slotThread2, 0);
                for (var count = 0; count < 5; count++)
                {
                    Thread.Sleep(2000);
                    var value = (int)Thread.GetData(slotThread2);
                    Clients.Caller.ThreadLocalStorageExample("Thread local storage 2: " + value);
                    value++;
                    Thread.SetData(slotThread2, value);
                }
            });

            Clients.Caller.ThreadLocalStorageExample("Thread local storage example started.");
            threadLocalStorage1.Start();
            Thread.Sleep(12000);
            threadLocalStorage2.Start();
            Thread.Sleep(12000);
            var mainThreadSlot = Thread.GetNamedDataSlot("Value");
            Thread.SetData(mainThreadSlot, 0);
            var mainValue = (int)Thread.GetData(mainThreadSlot);
            Clients.Caller.ThreadLocalStorageExample("Thread local storage result: " + mainValue);
            Clients.Caller.ThreadLocalStorageExample("Thread local storage example ended.");
        }

        public void ThreadPoolQueueWorkItemExample()
        {
            Action<string> sendMessage = (message) =>
            {
                Clients.Caller.ThreadPoolQueueWorkItemExample(message);
            };

            ThreadPool.QueueUserWorkItem(_ =>
            {
                RepeatMessageFiveTimes("Marco", sendMessage);
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                RepeatMessageFiveTimes("Polo", sendMessage);
            });
        }

        public void ThreadSynchronizationUsingMonitorExample()
        {
            var lockObject = new object();
            var count = 0;
            var iterationMax = 100000;

            var add = new Thread(() =>
            {
                for (var iterate = 0; iterate < iterationMax; iterate++)
                {
                    lock (lockObject)
                    {
                        count++;
                    }
                }
            });

            var subtract = new Thread(() =>
            {
                for (var iterate = 0; iterate < iterationMax; iterate++)
                {
                    lock (lockObject)
                    {
                        count--;
                    }
                }
            });

            Clients.Caller.ThreadSynchronizationUsingMonitorExample("Monitor synchronization example start. Time: " + DateTime.Now.ToString());
            Clients.Caller.ThreadSynchronizationUsingMonitorExample("Starting value: " + count.ToString("N0"));
            Clients.Caller.ThreadSynchronizationUsingMonitorExample("Adding and subtracting " + iterationMax.ToString("N0") + " from different threads.");

            add.Start();
            subtract.Start();

            subtract.Join();
            add.Join();

            Clients.Caller.ThreadSynchronizationUsingMonitorExample("Monitor synchronization example end. Time: " + DateTime.Now.ToString());
            Clients.Caller.ThreadSynchronizationUsingMonitorExample("Ending value: " + count.ToString("N0"));
        }

        public void ThreadSynchronizationUsingMutexExample()
        {
            using (var exampleMutex = new Mutex())
            {
                var count = 0;
                var iterationMax = 100000;

                var add = new Thread(() =>
                {
                    for (var iterate = 0; iterate < iterationMax; iterate++)
                    {
                        exampleMutex.WaitOne();
                        count++;
                        exampleMutex.ReleaseMutex();
                    }
                });

                var subtract = new Thread(() =>
                {
                    for (var iterate = 0; iterate < iterationMax; iterate++)
                    {
                        exampleMutex.WaitOne();
                        count--;
                        exampleMutex.ReleaseMutex();
                    }
                });

                Clients.Caller.ThreadSynchronizationUsingMutexExample("Mutex synchronization example start. Time: " + DateTime.Now.ToString());
                Clients.Caller.ThreadSynchronizationUsingMutexExample("Starting value: " + count.ToString("N0"));
                Clients.Caller.ThreadSynchronizationUsingMutexExample("Adding and subtracting " + iterationMax.ToString("N0") + " from different threads.");

                add.Start();
                subtract.Start();

                subtract.Join();
                add.Join();

                Clients.Caller.ThreadSynchronizationUsingMutexExample("Mutex synchronization example end. " + DateTime.Now.ToString());
                Clients.Caller.ThreadSynchronizationUsingMutexExample("Ending value: " + count.ToString("N0"));
            }
        }

        public void ThreadSynchronizationUsingSemaphoreExample()
        {
            using (var exampleSemaphore = new Semaphore(1, 1))
            {
                var count = 0;
                var iterationMax = 100000;

                var add = new Thread(() =>
                {
                    for (var iterate = 0; iterate < iterationMax; iterate++)
                    {
                        exampleSemaphore.WaitOne();
                        count++;
                        exampleSemaphore.Release();
                    }
                });

                var subtract = new Thread(() =>
                {
                    for (var iterate = 0; iterate < iterationMax; iterate++)
                    {
                        exampleSemaphore.WaitOne();
                        count--;
                        exampleSemaphore.Release();
                    }
                });

                Clients.Caller.ThreadSynchronizationUsingSemaphoreExample("Semaphore synchronization example start. Time: " + DateTime.Now.ToString());
                Clients.Caller.ThreadSynchronizationUsingSemaphoreExample("Starting value: " + count.ToString("N0"));
                Clients.Caller.ThreadSynchronizationUsingSemaphoreExample("Adding and subtracting " + iterationMax.ToString("N0") + " from different threads.");

                add.Start();
                subtract.Start();

                subtract.Join();
                add.Join();

                Clients.Caller.ThreadSynchronizationUsingSemaphoreExample("Semaphore synchronization example end. " + DateTime.Now.ToString());
                Clients.Caller.ThreadSynchronizationUsingSemaphoreExample("Ending value: " + count.ToString("N0"));
            }
        }

        public void ThreadSynchronizationUsingManualResetEventExample()
        {
            Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Thread synchonization example using ManualResetEvent example started");

            var count = new int[] { 1, 2 };

            using (var threadBegin = new CountdownEvent(count.Count() * 3))
            using (var threadEnd = new CountdownEvent(count.Count() * 3))
            using (var thread1lock = new ManualResetEvent(false))
            using (var thread2lock = new ManualResetEvent(false))
            using (var thread3lock = new ManualResetEvent(false))
            {
                count.Select(s => new Thread(() =>
                {
                    threadBegin.Signal();
                    thread1lock.WaitOne();

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 1 thread " + s + ": Started");

                    Thread.Sleep(10000);

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 1 thread " + s + ": Finished");
                    threadEnd.Signal();
                }))
                .ToList()
                .ForEach(f => f.Start());

                count.Select(s => new Thread(() =>
                {
                    threadBegin.Signal();
                    thread2lock.WaitOne();

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 2 thread " + s + ": Started");

                    Thread.Sleep(5000);

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 2 thread " + s + ": Finished");
                    threadEnd.Signal();
                }))
                .ToList()
                .ForEach(f => f.Start());

                count.Select(s => new Thread(() =>
                {
                    threadBegin.Signal();
                    thread3lock.WaitOne();

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 3 thread " + s + ": Started");

                    Thread.Sleep(500);

                    Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Set 3 thread " + s + ": Finished");
                    threadEnd.Signal();
                }))
                .ToList()
                .ForEach(f => f.Start());

                threadBegin.Wait();
                thread1lock.Set();
                Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Thread Set 1 Started.");
                thread2lock.Set();
                Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Thread Set 2 Started.");
                thread3lock.Set();
                Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Thread Set 3 Started.");
                threadEnd.Wait();

                Clients.Caller.ThreadSynchronizationUsingManualResetEventExample("Thread synchonization example using ManualResetEvent example ended");
            }
        }

        private void RepeatMessageFiveTimes(string message, Action<string> signalRMethod)
        {
            for (var count = 0; count < 5; count++)
            {
                Thread.Sleep(2000);
                signalRMethod(message);
            }
        }
    }
}