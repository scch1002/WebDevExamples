using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Threading;

namespace WebDevExamples.WebTech.CSharp.TaskParallelismAndDataParallelism
{
    public class TaskParallelismAndDataParallelismHub : Hub
    {
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

        private string TestMethod(string message)
        {
            Thread.Sleep(2000);
            return message;
        }
    }
}