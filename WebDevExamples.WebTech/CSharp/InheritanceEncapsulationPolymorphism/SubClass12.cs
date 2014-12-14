using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism
{
    public class SubClass12 : SubClass1
    {
        public new int Method()
        {
            return 1;
        }

        public new string Method(string example)
        {
            return "Example";
        }
    }
}