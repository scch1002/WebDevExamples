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
            return View(new IndexVm());
        }


        [HttpPost]
        public ActionResult Index(List<List<string>> ConcatStrings, List<List<int>> SumNumbers)
        {
            var concatList = new TaskList<StringConcatTask>();
            var sumList = new TaskList<SumIntegerTask>();
            
            concatList.AddRange(from concat in ConcatStrings
                              select
                                new StringConcatTask
                                {
                                    StringList = concat
                                });

            sumList.AddRange(from sum in SumNumbers
                          select
                              new SumIntegerTask
                              {
                                  IntegerList = sum
                              });

            concatList.PerformListTasks();
            sumList.PerformListTasks();

            return View(new IndexVm {
                    ConcatResults = (from concat in concatList select concat.ConcatResult).ToList(),
                    SumResults = (from sum in sumList select sum.SumResult).ToList()
                });
        }
	}
}