using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.Events
{
    public class ExampleEventArgs : EventArgs
    {
        public ExampleEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}