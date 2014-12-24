using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevExamples.WebTech.CSharp.CovarianceAndContravariance;

namespace WebDevExamples.WebTech.Controllers
{
    public class CovarianceAndContravarianceController : Controller
    {
        public ActionResult Index()
        {
            var covariance = new SubClass[] 
                {
                    new SubClass { Value = "Test" },
                    new SubClass { Value = "Test2" },
                    new SubClass {Value = "Test3" }
                };

            var contravariant = new SubClass { Value = "Test" };

            IExampleMethods<Base, SubSubClass> example = new ExampleClass(covariance, contravariant);

            return View(new IndexVm
            {
                CovarianceResult = example.CovariantMethod(),
                ContravarianceInput = contravariant,
                ContravarianceResult = example.ContravariantMethod(new SubSubClass { Value = "Test" })
            });
        }
	}
}