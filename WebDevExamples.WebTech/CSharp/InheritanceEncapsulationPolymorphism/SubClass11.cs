﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism
{
    public class SubClass11 : SubClass1
    {
        public override int Method()
        {
            return base.Method() + 1;
        }

        public override string Method(string example)
        {
            return base.Method(example) + " from SubClass11";
        }
    }
}