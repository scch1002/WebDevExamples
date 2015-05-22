using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebDevExamples.WebTech.CSharp.Delegates
{
    public class DelegatesHub : Hub
    {
        private delegate string SimpleDelegate(string message);

        public void SimpleDelegateExample()
        {
            SimpleDelegate simpleDelegateExample = (message) => message + " example.";

            Clients.All.simpleDelegateExample(simpleDelegateExample("Simple delegate"));
        }

        public void AsyncDelegateExample()
        {

        }
    }
}