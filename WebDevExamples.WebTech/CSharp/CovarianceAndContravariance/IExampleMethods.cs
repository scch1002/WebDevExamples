using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevExamples.WebTech.CSharp.CovarianceAndContravariance
{
    public interface IExampleMethods<out T, in R> where T : Base where R : Base
    {
        T[] CovariantMethod();
        bool ContravariantMethod(R example);
    }
}
