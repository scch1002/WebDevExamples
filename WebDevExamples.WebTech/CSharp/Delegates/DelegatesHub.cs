using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Runtime.Remoting.Messaging;

namespace WebDevExamples.WebTech.CSharp.Delegates
{
    public class DelegatesHub : Hub
    {
        private delegate string ExampleDelegate(string message);
        private delegate void MulticastExample(string message);

        public void SimpleDelegateExample()
        {
            ExampleDelegate simpleDelegateExample = (message) => message + " example.";

            Clients.Caller.simpleDelegateExample(simpleDelegateExample("Simple delegate"));
        }

        public void AsyncDelegateExample()
        {
            ExampleDelegate asyncDelegate = (message) => 
                {
                    for(var count = 0; count < 5; count++) {
                        Clients.Caller.asyncDelegateExample("This is message " + count + ".");
                    }
                    
                    return "The async method has finished." + message;
                };

            asyncDelegate.BeginInvoke(" Hello There.", AsyncCallBackExample, null);
        }

        private void AsyncCallBackExample(IAsyncResult ar)
        {
            Clients.Caller.asyncDelegateExample("The callback as been called.");
            
            AsyncResult result = (AsyncResult)ar;
            var caller = (ExampleDelegate)result.AsyncDelegate;

            Clients.Caller.asyncDelegateExample(caller.EndInvoke(ar));
        }

        public void MulticastDelegateExample()
        {
            MulticastExample multicastDelegate1 = (message) => 
            {
                Clients.Caller.multicastDelegateExample("Delegate 1: " + message);  
            };

            MulticastExample multicastDelegate2 = (message) =>
            {
                Clients.Caller.multicastDelegateExample("Delegate 2: " + message);
            };

            MulticastExample multicastDelegate3 = (message) =>
            {
                Clients.Caller.multicastDelegateExample("Delegate 3: " + message);
            };

            MulticastExample combineDelegates = multicastDelegate1;

            combineDelegates += multicastDelegate2;
            combineDelegates += multicastDelegate3;

            combineDelegates("Multicast Delegate Example");

            Clients.Caller.multicastDelegateExample("The end of the multicast delegate.");
        }
    }
}