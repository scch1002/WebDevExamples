using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace WebDevExamples.WebTech.CSharp.TaskParallelismAndDataParallelism
{
    public class TaskParallelismAndDataParallelismHub : Hub
    {
        private readonly static ConcurrentDictionary<string, CancellationTokenSource> _connections = new ConcurrentDictionary<string, CancellationTokenSource>();
        
        public override Task OnConnected()
        {
            _connections.AddOrUpdate(Context.ConnectionId, new CancellationTokenSource(),
                    (connectionId, existSource) => existSource.IsCancellationRequested ? new CancellationTokenSource() : existSource);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            CancellationTokenSource cancellationTokenSource;
            if (_connections.TryRemove(Context.ConnectionId, out cancellationTokenSource)) 
            { 
                cancellationTokenSource.Cancel();
            };
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            _connections.AddOrUpdate(Context.ConnectionId, new CancellationTokenSource(),
                    (connectionId, existSource) => existSource.IsCancellationRequested ? new CancellationTokenSource() : existSource);
            return base.OnReconnected();
        }
        
        public void SimpleTaskExample()
        {
            var simpleTask = new Task<string>(() =>
            {
                return TestMethod("This is a simple task example.");
            });
            simpleTask.Start();
            Clients.Caller.SimpleTaskExample(simpleTask.Result);
        }

        public void TaskFactoryExample()
        {
            var taskFactoryExample = Task<string>.Factory.StartNew(() =>
                {
                    return TestMethod("This is a task factory example.");
                });
            Clients.Caller.TaskFactoryExample(taskFactoryExample.Result);
        }

        public void TaskRunExample()
        {
            var taskRunExample = Task.Run(() =>
            {
                return TestMethod("This is a task run example.");
            });
            Clients.Caller.TaskRunExample(taskRunExample.Result);
        }

        public void TaskCancellationExample()
        {
            var cancellationTokenSource = _connections.AddOrUpdate(Context.ConnectionId, new CancellationTokenSource(),
                    (connectionId, existSource) => existSource.IsCancellationRequested ? new CancellationTokenSource() : existSource);

            var cancellationToken = cancellationTokenSource.Token;

            var taskCancellationExample = Task.Run(() =>
            {
                for (var count = 0; count < 1000; count++)
                {
                    Thread.Sleep(5000);
                    Clients.Caller.TaskCancellationExample("Hi, It is " + DateTime.Now.ToString() + " and I am still here.");
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Clients.Caller.TaskCancellationExample("The task as been cancelled.");
                        return;
                    }
                }
                Clients.Caller.TaskCancellationExample("The task was not cancelled.");
            },
            cancellationToken);
        }

        public void TaskCancellationExampleCancelTasks()
        {
            _connections.GetOrAdd(Context.ConnectionId, new CancellationTokenSource()).Cancel();
        }

        public void TaskExceptionExample(bool failNotHandle, bool failHandle)
        {
            var parentTask = new Task<string>(() =>
            {
                var childTask = new Task<string>(() =>
                {
                    var childchildTask = new Task<string>(() =>
                    {
                        throw new ArgumentNullException("There was an argument problem.");
                        return "This is the child child result.";
                    });
                    childchildTask.Start();
                    throw new ArgumentException("What argument?");
                    return "This is the child result.";
                });

                var otherChildTask = new Task<string>(() =>
                {
                    throw new FormatException("What is this?");
                    return "This is another result";
                });

                childTask.Start();
                otherChildTask.Start();

                if (failNotHandle)
                {
                    throw new Exception("Oh why not.");
                }
                
                if (failHandle)
                {
                    throw new ArgumentException("This will not cause a failure.");
                }
                    
                return "This is the parent result.";
            });
            
            parentTask.Start();

            try
            {
                try
                {
                    Clients.Caller.TaskExceptionExample(parentTask.Result);
                }
                catch (AggregateException aggregateException)
                {
                    aggregateException.Handle(exception =>
                    {
                        if (HandleException(exception, typeof(ArgumentException)) ||
                            HandleException(exception, typeof(ArgumentNullException)) ||
                            HandleException(exception, typeof(FormatException)))
                        {
                            return true;
                        }
                        return false;
                    });
                }
            }
            catch (Exception exception)
            {
                Clients.Caller.TaskExceptionExample("Aggregate exception handler did not handle an exception.");
            }            
            
            if (parentTask.IsFaulted)
            {
                Clients.Caller.TaskExceptionExample("The operation failed.");
                return;
            }

            Clients.Caller.TaskExceptionExample("The operation succeeded.");
        }

        public void TaskContinuationExample()
        {
            var task1 = new Task<string>(() =>
            {
                Clients.Caller.TaskContinuationExample("This is the start of the task chain.");
                return "Task 1 Result";
            });
            
            var task1ContinueWith = task1.ContinueWith<string>(t1 =>
            {
                Clients.Caller.TaskContinuationExample(t1.Result);
                return "Task 2 Result and end of chain.";
            });

            var exceptionContinuationTask = new Task(() =>
            {
                Clients.Caller.TaskContinuationExample("Start of continuation exception");
                throw new Exception("This is an example exception.");
            });

            exceptionContinuationTask.ContinueWith(t => 
            {
                Clients.Caller.TaskContinuationExample("Exception has been caught.");
            }, TaskContinuationOptions.OnlyOnFaulted);

            task1.Start();
            Clients.Caller.TaskContinuationExample(task1ContinueWith.Result);
            exceptionContinuationTask.Start();
        }

        public void ParallelInvokeExample()
        {
            var messageCollection = new Action[40];
            for(var count = 0; count < 40; count++)
            {
                var currentCount = count;
                messageCollection[count] = () => Clients.Caller.ParallelInvokeExample(TestMethod("Hello, this is method number " + currentCount));
            }
            Parallel.Invoke(messageCollection);
        }

        public void ParallelForExample()
        {
            Parallel.For(0, 40, count =>
            {
                Clients.Caller.ParallelForExample(TestMethod("Hello, this is method number " + count));
            });
        }

        public void ParallelForEachExample()
        {
            var xs = Enumerable.Range(0, 1000000);
            var total = 0L;

            Parallel.ForEach(xs,
                () => 0L,
                (x, loop, subtotal) =>
                {
                    subtotal += x;
                    return subtotal;
                },
                subtotal => Interlocked.Add(ref total, subtotal)
                );

            Clients.Caller.ParallelForEachExample("The total is:" + total);
        }

        private static string TestMethod(string message)
        {
            Thread.Sleep(2000);
            return message;
        }

        private static bool HandleException(Exception exception, Type isExceptionTypeOf)
        {
            return exception.GetType() == isExceptionTypeOf;
        }
    }
}