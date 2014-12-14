using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.Domain
{
    public class Base
    {
        public virtual int Method()
        {
            return 1;
        }

        public virtual string Method(string example)
        {
            return example;
        }
    }
}