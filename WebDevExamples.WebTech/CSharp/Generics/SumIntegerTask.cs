using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.Generics
{
    public class SumIntegerTask : IProcessTask
    {
        public List<int> IntegerList { get; set; }

        public int SumResult { get; set; }

        public bool ProcessTask()
        {
            SumResult = IntegerList.Sum();

            return true;
        }
    }
}