using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebDevExamples.WebTech.CSharp.InheritanceEncapsulationPolymorphism;

namespace WebDevExamples.WebTech.Controllers
{
    public class InheritanceEncapsulationPolymorphismController : Controller
    {
        public ActionResult Index()
        {
            var exampleClasses = from type in Assembly.GetAssembly(typeof(IOutputMethod1And2))
                                    .GetTypes()
                                    .Where(w => w.GetInterfaces().Any(w1 => w1.Name == "IOutputMethod1And2"))
                                 select
                                     (IOutputMethod1And2)Activator.CreateInstance(type);

            return View(new IndexVm {
                ExampleClassOutputs = ProcessExampleClasses(exampleClasses.ToList())
            });
        }

        private IList<ExampleClassOutput> ProcessExampleClasses(IList<IOutputMethod1And2> exampleClasses)
        {
            return (from exampleProcess in exampleClasses
                         select
                             new ExampleClassOutput
                             {
                                 ClassName = exampleProcess.GetType().Name,
                                 Method1 = exampleProcess.Method(),
                                 Method2 = exampleProcess.Method("Example")
                             }).ToList();
        } 
	}
}