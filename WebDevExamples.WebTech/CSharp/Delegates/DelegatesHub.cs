using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebDevExamples.WebTech.CSharp.Delegates
{
    public class DelegatesHub : Hub
    {
        private delegate string ExampleDelegate(string message);

        public void SimpleDelegateExample()
        {
            ExampleDelegate simpleDelegateExample = (message) => message + " example.";

            Clients.All.simpleDelegateExample(simpleDelegateExample("Simple delegate"));
        }

        public void AsyncDelegateExample()
        {
            ExampleDelegate asyncDelegate = (message) => 
                {
                    for(var count = 0; count < 5; count++) {
                        Clients.All.asyncDelegateExample("This is message " + count + ".");
                    }
                    
                    return "The async method has finished." + message;
                };

            var result = asyncDelegate.BeginInvoke("")
        }
    }
}