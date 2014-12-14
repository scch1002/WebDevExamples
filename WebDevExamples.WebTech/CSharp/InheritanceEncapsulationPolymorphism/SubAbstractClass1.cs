using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism
{
    public class SubAbstractClass1 : BaseAbstract
    {
        public override string Method(string example)
        {
            return example + " from Sub Abstract Class 1";
        }
    }
}