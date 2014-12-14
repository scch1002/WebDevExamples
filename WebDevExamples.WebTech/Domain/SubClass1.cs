using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.Domain
{
    public class SubClass1 : Base
    {
        public override int Method()
        {
            return base.Method() + 1;
        }

        public override string Method(string example)
        {
            return base.Method(example) + " from SubClass1";
        }
    }
}