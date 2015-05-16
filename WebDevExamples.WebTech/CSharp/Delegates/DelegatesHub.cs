using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebDevExamples.WebTech.CSharp.Delegates
{
    public class DelegatesHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Hello There");
        }
    }
}