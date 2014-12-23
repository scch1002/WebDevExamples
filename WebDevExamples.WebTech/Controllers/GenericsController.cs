using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevExamples.WebTech.CSharp.Generics;

namespace WebDevExamples.WebTech.Controllers
{
    public class GenericsController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexVm
            {
                ConcatInput = new List<string>(),
                SumInput = new List<int>(),
                ConcatResult = string.Empty,
                SumResult = 0
            });
        }
        
        [HttpPost]
        public ActionResult Index(List<string> ConcactInput, List<int> SumInput)
        {
            var concatList = new TaskList<StringConcatTask>();
            var sumList = new TaskList<SumIntegerTask>();
            
            concatList.Add(new StringConcatTask
                            {
                                StringList = ConcactInput
                            });

            sumList.Add(new SumIntegerTask
                        {
                            IntegerList = SumInput
                        });

            concatList.PerformListTasks();
            sumList.PerformListTasks();

            return View(new IndexVm {
                    ConcatInput = ConcactInput,
                    SumInput = SumInput,
                    ConcatResult = concatList[0].ConcatResult, 
                    SumResult = sumList[0].SumResult
                });
        }
	}
}