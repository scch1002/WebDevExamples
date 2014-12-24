using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.CovarianceAndContravariance
{
    public class ExampleClass : IExampleMethods<SubClass, SubClass>
    {
        private readonly SubClass[] _covariantExample;
        private readonly SubClass _contravariantExample;

        public ExampleClass(SubClass[] covariantExample, SubClass contravariantExample)
        {
            _covariantExample = covariantExample;
            _contravariantExample = contravariantExample;
        }

        public SubClass[] CovariantMethod()
        {
            return _covariantExample;
        }

        public bool ContravariantMethod(SubClass example)
        {
            return _contravariantExample.Value.Equals(example.Value);
        }
    }
}