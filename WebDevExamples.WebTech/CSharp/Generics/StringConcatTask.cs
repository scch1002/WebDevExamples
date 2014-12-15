using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.Generics
{
    public class StringConcatTask : IProcessTask
    {
        public List<string> StringList { get; set; }

        public string ConcatResult { get; set; }

        public bool ProcessTask()
        {
            var concatStrings = string.Concat(StringList);

            ConcatResult = concatStrings;

            return true;
        }
    }
}