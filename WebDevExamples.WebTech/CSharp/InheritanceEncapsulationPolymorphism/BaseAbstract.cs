using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism
{
    public abstract class BaseAbstract : IOutputMethod1And2
    {

        public int Method()
        {
            return 100;
        }

        public abstract string Method(string example);
    }
}