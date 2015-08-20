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
                Thread.Sleep(2000);
                return "This is a simple task example";
            });
            simpleTask.Start();
            Clients.Caller.SimpleTaskExample(simpleTask.Result);
        }
    }
}