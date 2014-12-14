using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism;

namespace WebDevExamples.WebTech.Controllers
{
    public class InheritanceEncapsulationPolymorphismController : Controller
    {
        public ActionResult Index()
        {
            var exampleBase = new Base();
            var exampleSubClass1 = new SubClass1();
            var exampleSubClass2 = new SubClass2();
            var exampleSubClass11 = new SubClass11();

            return View(new IndexVm
                {
                    BaseMethod1Output = exampleBase.Method(),
                    BaseMethod2Output = exampleBase.Method("Example"),
                    SubClass1Method1Output = exampleSubClass1.Method(),
                    SubClass1Method2Output = exampleSubClass1.Method("Example"),
                    SubClass2Method1Output = exampleSubClass2.Method(),
                    SubClass2Method2Output = exampleSubClass2.Method("Example"),
                    SubClass11Method1Output = exampleSubClass11.Method(),
                    SubClass11Method2Output = exampleSubClass11.Method("Example")
                });
        }
	}
}