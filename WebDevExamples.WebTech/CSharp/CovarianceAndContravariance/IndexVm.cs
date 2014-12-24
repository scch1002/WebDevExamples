using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.CovarianceAndContravariance
{
    public class IndexVm
    {
        public Base[] CovarianceResult { get; set; }
        public Base ContravarianceInput { get; set; }
        public bool ContravarianceResult { get; set; }
    }
}